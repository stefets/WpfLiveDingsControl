namespace WpfLiveDings.OSC
{
    /*
     * http://dsacre.github.io/mididings/doc/index.html
     * http://dsacre.github.io/mididings/doc/extra.html
     * 
     * Known osc messages by mididings
     * 
        
        /mididings/switch_scene ,i: switch to the given scene number.
        /mididings/switch_subscene ,i: switch to the given subscene number.
        /mididings/prev_scene: switch to the previous scene.
        /mididings/next_scene: switch to the next scene.
        /mididings/prev_subscene: switch to the previous subscene.
        /mididings/next_subscene: switch to the next subscene.
        /mididings/panic: send all-notes-off on all channels and on all output ports.
        /mididings/quit: terminate mididings.

    */
    /// <summary>
    /// Wrapper Class to control MIDIDINGS over OSC in .NET
    /// </summary>
    public sealed class MididingsOsc : OscBase
    {

        private const string rootAddress = "/mididings";

        /// <summary>
        /// Initializes a new instance of the <see cref="MididingsOsc"/> class.
        /// </summary>
        /// <param name="address">The address.</param>
        /// <param name="port">The port.</param>
        public MididingsOsc(string address, int port = 56418, int notify_port = 56419)
            : base(rootAddress, address, port, notify_port)
        {
        }

        /// <summary>
        /// Switches the scene.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="callerName">Name of the caller.</param>
        public void switch_scene(int number)
        {
            Send(nameof(switch_scene), number);
        }

        /// <summary>
        /// Switches the sub scene.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="callerName">Name of the caller.</param>
        public void switch_subscene(int number)
        {
            Send(nameof(switch_subscene), number);
        }

        /// <summary>
        /// Previouse scene.
        /// </summary>
        public void prev_scene()
        {
            Send();
        }

        /// <summary>
        /// Next scene.
        /// </summary>
        public void next_scene()
        {
            Send();
        }

        /// <summary>
        /// Previous sub scene.
        /// </summary>
        public void prev_subscene()
        {
            Send();
        }

        /// <summary>
        /// Next sub scene.
        /// </summary>
        public void next_subscene()
        {
            Send();
        }

        /// <summary>
        /// Panic.
        /// </summary>
        public void panic()
        {
            Send();
        }

        public void query()
        {
            Send();
        }

        /// <summary>
        /// Quit.
        /// </summary>
        public void quit()
        {
            Send();
        }

    }
}
