using IronPython.Hosting;
using LACE.Adapters.RaspberryPi.Facts;
using LACE.Core.Abstractions;
using Microsoft.Scripting.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace LACE.Adapters.RaspberryPi.Meters
{
    public class GpioPinAdapter : IMeterAdapter
    {
        private readonly ScriptEngine _scriptEngine;
        private readonly string _scriptUri;

        private dynamic Pin => _scriptEngine.ExecuteFile(_scriptUri);

        public GpioPinAdapter(int pinPosition, string scriptUri)
        { // TODO: guard
            PinPosition = pinPosition;
            _scriptEngine = Python.CreateEngine();
            _scriptUri = scriptUri;
        }

        public int PinPosition { get; }

        public float Value
        {
            get => GetPinValue();
            set => SetPinValue(value);
        }

        private float GetPinValue()
        {
            var value = Pin.Read(PinPosition); // See script for method details

            if (value == null)
            {
                return default;
            }

            if (value is float floatValue)
            {
                return floatValue;
            }

            if (!(value is string stringValue))
            {
                return default;
            }

            if(!float.TryParse(stringValue, out floatValue))
            {
                return default;
            }

            return floatValue;
        }

        private void SetPinValue(float value)
        {
            Pin.Set(PinPosition, value); // See script for method details
        }

        public Task<IFact> ReadAsync(CancellationToken cancellation)
        {
            return Task.FromResult<IFact>(new FloatGpioPinFact
            {
                Measurement = Value
            });
        }
    }
}
