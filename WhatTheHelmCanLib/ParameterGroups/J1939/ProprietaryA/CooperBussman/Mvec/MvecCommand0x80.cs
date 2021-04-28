using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CanLib.ParameterGroups.J1939.ProprietaryA.CooperBussman.Mvec
{
    /// <summary>
    /// Represents and enumeration of possible relay state commands.
    /// </summary>
    public enum RelayCommandState
    {
        /// <summary>
        /// Turn relay off
        /// </summary>
        TurnRelayOff = 0,
        /// <summary>
        /// Turn relay on
        /// </summary>
        TurnRelayOn = 1,
        /// <summary>
        /// No change to relay state
        /// </summary>
        NoChange = 3,
    }
    /// <summary>
    /// Creates an object reference to a command to change the state of the relays within a grid of an MVEC module.
    /// </summary>
    public class MvecCommand0x80 : MvecCommand
    {
        public override CommandMessage Command
        {
            get
            {
                return CommandMessage.hex80;
            }
        }

        /// <summary>
        /// Represents the grid address where the relay to command is located.
        /// </summary>
        public byte GridAddress { get; private set; }
        /// <summary>
        /// Represents the target relay within the specified grid that the command will be invoked upon.
        /// </summary>
        public byte RelayToCommand { get; private set; }
        /// <summary>
        /// Represents the type of relay state requested by the command.
        /// </summary>
        public RelayCommandState RelayCommand { get; private set; }

        private const string _RelayOffCommandBin = "00";
        private const string _RelayOnCommandBin = "01";
        private const string _RelayNoChangeBin = "11";

        /// <summary>
        /// Creates an object reference to a command to change the state of the relays within a grid of an MVEC module using a defined grid address, target relay and commanded state of the target relay.
        /// </summary>
        /// <param name="gridAddress">Represents the grid address where the relay to command is located.</param>
        /// <param name="relayToCommand">Represents the target relay within the specified grid that the command will be invoked upon.</param>
        /// <param name="relayCommand">Represents the type of relay state requested by the command.</param>
        public MvecCommand0x80 (byte gridAddress, byte relayToCommand, RelayCommandState relayCommand)
        {
            GridAddress = gridAddress;
            RelayToCommand = relayToCommand;
            RelayCommand = relayCommand;
        }

        public override byte[] SerializeFields()
        {
            byte[] bytes = new byte[6];
            bytes[0] = (byte)Command;
            bytes[1] = GridAddress;

            string relayCommandBin = Convert.ToString((byte)RelayCommand, 2).PadLeft(8, '0').Substring(6,2);

            //Create relay status nibble array and fill all positions with NoChange enumeration.
            string[] nibbles = Enumerable.Repeat("11", 16).ToArray();
            nibbles[RelayToCommand - 1] = relayCommandBin;
            string nibbleStr = string.Empty;
            for(int i = 0; i< 16;i++)
            {
                nibbleStr = string.Concat(nibbles[i], nibbleStr);
            }

            Enumerable.Range(0, int.MaxValue / 8)
            .Select(i => i * 8)
            .TakeWhile(i => i < nibbleStr.Length)
            .Select(i => nibbleStr.Substring(i, 8))
            .Select(s => Convert.ToByte(s, 2))
            .ToArray().Reverse().ToArray().CopyTo(bytes,2);

            return bytes;
        }
    }
}
