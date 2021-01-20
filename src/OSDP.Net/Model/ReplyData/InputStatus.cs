using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OSDP.Net.Model.ReplyData
{
    /// <summary>
    /// The input status report of the PD sent as a reply.
    /// </summary>
    public class InputStatus
    {
        private InputStatus()
        {
        }

        /// <summary>
        /// Gets the all the PD's input statuses as an array ordered by input number.
        /// </summary>
        public IEnumerable<bool> InputStatuses { get; private set; }

        internal static InputStatus ParseData(ReadOnlySpan<byte> data)
        {
            return new InputStatus {InputStatuses = data.ToArray().Select(Convert.ToBoolean)};
        }

        /// <inheritdoc />
        public override string ToString()
        {
            byte inputNumber = 0;
            var build = new StringBuilder();
            foreach (bool inputStatus in InputStatuses)
            {
                build.AppendLine($"Input Number {inputNumber++:00}: {inputStatus}");
            }

            return build.ToString();
        }
    }
}