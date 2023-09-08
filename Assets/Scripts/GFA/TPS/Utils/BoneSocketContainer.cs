using UnityEngine;

namespace GFA.TPS.Utils
{
    public class BoneSocketContainer : MonoBehaviour
    {
        private BoneSocket[] _sockets;
        private void Awake()
        {
            _sockets = GetComponentsInChildren<BoneSocket>();
        }

        public bool TryGetSocket(string socketName, out Transform socket)
        {
            var x = GetSocket(socketName);
            if (x)
            {
                socket = x;
                return true;
            }
            socket = null;
            return false;
        }
        
        public Transform GetSocket(string socketName)
        {
            foreach (var socket in _sockets)
            {
                if (socket.SocketName == socketName)
                {
                    return socket.transform;
                }
            }

            return null;
        }
    }
}
