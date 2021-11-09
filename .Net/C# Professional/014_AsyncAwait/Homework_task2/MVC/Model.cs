using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Homework_task2
{
    class Model
    {
        object asyncBlock = new object();

        public bool DBIsConnected { private set; get; }

        /// <returns>Returns the connection status</returns>
        internal bool ConnectDB()
        {
            lock (asyncBlock)
            {
                Random random = new();

                // Code connect to the DB
                Thread.Sleep(random.Next(1000, 4000));  // Random sleep time
                DBIsConnected = random.Next(0, 3) > 0;  // Random true or false

                // Return the connection status
                return DBIsConnected;
            }
        }
        /// <returns>Returns Task"bool" with the connection status</returns>
        internal async Task<bool> ConnectDBAsync()
        {
            Task<bool> connectDB = Task.Factory.StartNew(ConnectDB);
            return await connectDB;
        }

        // I specifically made the disconnection very similar to the connection to better check that in all cases the program works stably
        /// <returns>Returns the connection status</returns>
        internal bool DisconnectDB()
        {
            lock (asyncBlock)
            {
                Random random = new();

                // Code disconnect to the DB
                Thread.Sleep(random.Next(1000, 4000));  // Random sleep time
                DBIsConnected = random.Next(0, 2) > 0;  // Random value true or false to check all situations and stability

                // Return the connection status
                return DBIsConnected;
            }
        }
        /// <returns>Returns Task"bool" with the connection status</returns>
        internal async Task<bool> DisconnectDBAsync()
        {
            Task<bool> disconnectDB = Task.Factory.StartNew(DisconnectDB);
            return await disconnectDB;
        }
    }
}
