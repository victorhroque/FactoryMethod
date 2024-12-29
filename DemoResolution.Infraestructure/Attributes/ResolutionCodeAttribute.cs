namespace DemoResolution.Infraestructure.Attributes
{
    internal class ResolutionCodeAttribute : Attribute
    {
        public string _resolutionCode;

        public ResolutionCodeAttribute(string resolutionCode)
        {
            _resolutionCode = resolutionCode;
        }
    }
}
