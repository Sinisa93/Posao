using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArgosyModel;

namespace Argosy.BusinessLogic.Extensions
{
    public static class ConsumerExtensions
    {
        public static IEnumerable<ESM_ORDERS> GetConsumerOrders(this ESM_CONSUMER consumer)
        {
            return consumer.ESM_ORDERS;
        }

        public static string GetStateCode(this ESM_CONSUMER consumer)
        {
            var stateCode = string.Empty;
            if (consumer.ESM_STATES != null)
            {
                stateCode = consumer.ESM_STATES.STATE_CODE;
            }
            return stateCode;
        }
    }
}
