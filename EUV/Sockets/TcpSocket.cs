using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using EUV.Messages;
using EUV.Controls;
using EUV.Utility;

namespace EUV.Sockets
{
    #region TcpSocket
    class TcpSocket
    {
        #region 선언문

        #region 변수선언

        private static TcpSocket _instance;

        private Socket _serverSocket;
        private int _port;
        private bool _boolSocket = false;

        private Thread _acceptThread;

        public List<ConnectionInfo> _connections = new List<ConnectionInfo>();

        object locking = new object();

        #endregion

        #region 생성자 및 인스턴스 반환
        public TcpSocket(int port)
        {
            _port = port;
        }

        public static TcpSocket _getInstance()
        {
            if (_instance == null)
                _instance = new TcpSocket(Commons.Envi._SocketPort);

            return _instance;
        }
        #endregion

        #endregion

        #region 메소드

        #region 시작
        internal void _start()
        {
            _boolSocket = _setupServerSocket();

            _acceptThread = new Thread(_acceptConnections)
            {
                Name = "AcceptConnections Thread"
            };
            _acceptThread.Start();

            //OutputWindow.addText(1, Resources.Messages.Socket_Message005);
        }
        #endregion

        #region 새로운 연결 만들기
        private void _acceptConnections()
        {
            while (_boolSocket)
            {
                try
                {
                    Thread.Sleep(2);//DEnvironment.socketTimer);        //Properties.Settings.Default.SocketTimer);
                }
                catch (Exception ex)
                {
                    Tools._debugLog(ex.ToString());
                }
                try
                {
                    Socket _socket = _serverSocket.Accept();

                    ConnectionInfo _connection = new ConnectionInfo
                    {
                        _idInfo = -10,// socket.RemoteEndPoint.ToString();

                        _socketInfo = _socket,

                        _threadInfo = new Thread(_processConnection)
                    };
                    _connection._threadInfo.IsBackground = true;
                    _connection._threadInfo.Start(_connection);

                    lock (_connections) _connections.Add(_connection);
                }
                catch (SocketException se)
                {
                    if (se.ErrorCode == 10004)//WSACancelBlockingCall
                    {
                        Tools._debugLog(se.ToString());
                    }
                    else
                    {
                        Tools._debugLog(se.ToString());
                    }
                }
                catch (Exception ex)
                {
                    Tools._debugLog(ex.ToString());
                }
            }
        }
        #endregion

        #region 소켓 만들기
        private bool _setupServerSocket()
        {
            try
            {
                IPAddress _ipaddr = IPAddress.Parse(Commons.Envi._IPAddress);
                IPEndPoint myEndpoint = new IPEndPoint(_ipaddr, _port);

                _serverSocket = new Socket(myEndpoint.Address.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                _serverSocket.Bind(myEndpoint);
                _serverSocket.Listen(100);

                return true;
            }
            catch (SocketException se)
            {
                if (se.ErrorCode == 10048)
                {
                    Tools._debugLog("소켓이 사용중입니다. 소켓(IP)을 확인후 프로그램을 재시작하여주세요.");
                }
                else if (se.ErrorCode == 10013)
                {
                    Tools._debugLog("액세스 권한에 의해 숨겨진 소켓에 액세스를 시도했습니다. 소켓(PORT)을 확인후 프로그램을 재시작하여주세요.");
                }
                return false;

            }
        }
        #endregion

        #region TCP 데이터 수신
        private void _processConnection(object state)
        {
            ConnectionInfo _connection = (ConnectionInfo)state;

            try
            {
                byte[] _tempBuffer = new byte[0];    //수신 데이터 저장소
                while (true)
                {
                    byte[] _buffer = new byte[1];    //소켓 수신
                    int _bytesRead = _connection._socketInfo.Receive(_buffer, 1, 0);
                    if (_bytesRead > 0)
                    {
                        if (_buffer[0].GetHashCode() == 0)   //'\0'은 null(쓰레기값)
                        { continue; }

                        IEnumerable<byte> _rv = _tempBuffer.Concat(_buffer);
                        _tempBuffer = _rv.ToArray();

                        if (_buffer[0].GetHashCode() == 37)  //'%'가 오면 마지막
                        {
                            lock (locking)
                            {
                                bool b = MessageParser._getInstance().parsing(_tempBuffer, _connection._socketInfo.RemoteEndPoint.ToString());
                            }
                            _tempBuffer = new byte[0];
                        }
                        #region echo (to client)
                        ///메아리
                        //lock (_connections)
                        //{
                        //    foreach (ConnectionInfo conn in _connections)
                        //    {
                        //        if (conn != connection)
                        //        {
                        //            conn.SocketInfo.Send(buffer, bytesRead, SocketFlags.None);
                        //        }
                        //    }
                        //}

                        ///OK 전송
                        //string echo = "OK";
                        //byte[] buff = Encoding.GetEncoding(949).GetBytes(echo);

                        //connection.SocketInfo.Send(buff, SocketFlags.None);
                        #endregion
                    }
                    else if (_bytesRead == 0) return;
                }
            }
            catch (SocketException se)
            {
                if (se.ErrorCode == 10054)//Connection Reset By Peer
                {
                    //string phonenumber = ProductionSPs.getUSERPHONENUMBER(connection._idInfo); //1번 유저에게만 알림
                    //SendMessage.Instance.sendSMS(string.Format(Resources.Messages.Socket_Message007, connection._idInfo.ToString()), phonenumber);
                    //SendMessage.Instance.sendSMS(connection.idInfo.ToString() + " 장치와 연결이 종료되었습니다.(네트워크 오류)", phonenumber);
                }
                Tools._debugLog("Socket Exception " + se.ErrorCode.ToString());
            }
            catch (Exception ex)
            {
                Tools._debugLog(ex.ToString());
            }
            finally
            {
                _connection._socketInfo.Close();
                lock (_connections) _connections.Remove(_connection);

                int index = AllAboutMessages._getInstance().VehicleMessages.FindIndex(c => c.id == _connection._idInfo);
                if ( index >=0 ) 
                    AllAboutMessages._getInstance().VehicleMessages.RemoveAt(index);
            }
        }
        #endregion

        #region Send TCP Message

        #region All
        internal int _sendmessage(string message)
        {
            int result = 0;
            byte[] buffer = new byte[255];
            buffer = Encoding.GetEncoding(949).GetBytes(message);
            foreach (ConnectionInfo _conn in _connections)
            {
                if (_conn._socketInfo != null)
                {
                    _conn._socketInfo.Send(buffer, SocketFlags.None);
                    result++;
                }
            }
            Tools._writeLine("ALL : " + message);
            return result;  //보낸 횟수
        }
        #endregion

        #region ID
        internal int _sendmessage(string message, int pdid)
        {
            int _result = -1;
            ConnectionInfo _conn = null;
            foreach (ConnectionInfo _ci in _connections)
            {
                if (pdid == _ci._idInfo)
                    _conn = _ci;
            }

            byte[] _buffer = Encoding.GetEncoding(949).GetBytes(message);
            if (_conn != null && _conn._socketInfo != null)
            {
                _result = _conn._socketInfo.Send(_buffer, SocketFlags.None);
                //OutputWindow.addText(0, "Send TCP : " + pdid + " " + message);
                Tools._writeLine("send TCP : " + pdid + " " + message);
            }
            return _result;  //보낸 바이트 수
        }
        #endregion

        #region Object
        internal int _sendmessage(string message, object state)
        {
            int _result = -1;
            ConnectionInfo _conn = (ConnectionInfo)state;
            byte[] _buffer = new byte[255];
            _buffer = Encoding.GetEncoding(949).GetBytes(message);
            if (_conn._socketInfo != null)
            {
                _result = _conn._socketInfo.Send(_buffer, SocketFlags.None);
                Tools._writeLine("send TCP : " + _conn._idInfo.ToString() + " " + message);
            }
            return _result;
        }
        #endregion

        #endregion

        #region Closed Socket and Thread

        #region Closed Socket
        public void _closedSocket()
        {
            _boolSocket = false;
            _closedThread();
            try
            {
                foreach (ConnectionInfo info in _connections)
                {
                    if (info._socketInfo != null)
                    {
                        info._socketInfo.Shutdown(SocketShutdown.Both);
                    }
                }
                if (_serverSocket != null)
                {
                    _serverSocket.Close();
                }
                //OutputWindow.addText(1, Resources.Messages.Socket_Message006);
            }
            catch (Exception ex)
            {
                Tools._debugLog(ex.ToString());
            }
            finally
            {
                lock (_connections) _connections.RemoveAll(_locking);
            }
        }
        private bool _locking(ConnectionInfo c)
        {
            return true;
        }
        #endregion

        #region Colsed Thread
        public void _closedThread()
        {
            _boolSocket = false;

            if (_acceptThread != null)
            {
                while (_acceptThread.ThreadState == ThreadState.WaitSleepJoin)
                {
                    _acceptThread.Interrupt();
                    _acceptThread.Abort();
                }
            }
        }
        #endregion

        #endregion

        #region Set Socket ID (in Connectioninfo)
        public void _setSocketID(int id, string address)
        {
            foreach (ConnectionInfo _ci in _connections)
            {
                if (_ci._socketInfo.RemoteEndPoint.ToString() == address)
                {
                    _ci._idInfo = id;
                }
            }
        }
        #endregion

        #region 소켓 구동 여부 확인
        public bool _checkSocket
        {
            get { return _boolSocket; }
        }
        #endregion

        internal string _getRemoteEndPoint(int pdid)
        {
            string _result = "";
            ConnectionInfo _conn = null;
            foreach (ConnectionInfo _ci in _connections)
            {
                if (pdid == _ci._idInfo)
                    _conn = _ci;
            }

            if (_conn != null && _conn._socketInfo != null)
            {
                IPEndPoint ip = _conn._socketInfo.RemoteEndPoint as IPEndPoint;
                _result = ip.Address.ToString();
                //OutputWindow.addText(0, "Send TCP : " + pdid + " " + message);
                Tools._writeLine("Get remote ip : " + pdid + " : " + _result);
            }
            return _result;
        }

        #endregion
    }
    #endregion

    #region ConnectionInfo
    class ConnectionInfo
    {
        public int _idInfo;
        public Socket _socketInfo;
        public Thread _threadInfo;

        public void setIDInfo(int id)
        {
            _idInfo = id;
        }
    }
    #endregion
}
