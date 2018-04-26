using Argosy.Common.Contracts.Core.Interfaces;

namespace Argosy.Common.Contracts.Contract
{
    public class FileParameter : IFileParameter {
        public FileParameter() {

        }

        public FileParameter(string key, object value) {
            this.Key = key;
            this.Value = value;
        }
        public string Key { get; set; }
        public object Value { get; set; }
    }
}