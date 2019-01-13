using CoreOSC;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace WpfLiveDings.OSC
{
    public abstract class OscBase
    {

        /// <summary>
        /// Gets or sets the sender.
        /// </summary>
        /// <value>
        /// The sender.
        /// </value>
        protected UDPSender Sender { get; set; }
        /// <summary>
        /// Gets or sets the listener.
        /// </summary>
        /// <value>
        /// The listener.
        /// </value>
        protected UDPListener Listener { get; set; }
        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        protected string Address { get; set; }
        /// <summary>
        /// Gets or sets the port.
        /// </summary>
        /// <value>
        /// The port.
        /// </value>
        protected int Port { get; set; }
        /// <summary>
        /// Gets or sets the notify port.
        /// </summary>
        /// <value>
        /// The notify port.
        /// </value>
        protected int NotifyPort  { get; set; }
        /// <summary>
        /// Gets or sets the path.
        /// </summary>
        /// <value>
        /// The path.
        /// </value>
        protected string Path { get; set; }
        /// <summary>
        /// Gets or sets the osc messages.
        /// </summary>
        /// <value>
        /// The osc messages.
        /// </value>
        protected static List<OscMessage> OscMessages{ get; set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="OscBase"/> class.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="address">The address.</param>
        /// <param name="port">The port.</param>
        /// <param name="notify_port">The notify port.</param>
        protected OscBase(string path, string address, int port, int notify_port)
        {
            this.Path = path;
            this.Address = address;
            this.Port = port;
            this.NotifyPort = notify_port;

            this.Sender = new UDPSender(address, port);

            OscMessages = new List<OscMessage>();

            this.Listener = new UDPListener(notify_port, OnCallback);
        }

        /// <summary>
        /// Sends the specified caller name.
        /// </summary>
        /// <param name="callerName">Name of the caller.</param>
        protected void Send([CallerMemberName] string callerName = null)
        {
            this.Send(callerName, new object[0]);
        }

        /// <summary>
        /// Sends the specified caller name.
        /// </summary>
        /// <param name="callerName">Name of the caller.</param>
        /// <param name="values">The values.</param>
        protected void Send([CallerMemberName] string callerName = null, params object[] values)
        {
            this.Sender.Send(new OscMessage($"{this.Path}/{callerName}", values));

        }

        /// <summary>
        /// The on callback
        /// </summary>
        HandleOscPacket OnCallback = delegate(OscPacket packet)
        {
            OscMessage messageReceived = (OscMessage)packet;
            //OscMessages.Add(messageReceived);
            //Console.WriteLine(messageReceived.Address);
        };



    }
}
