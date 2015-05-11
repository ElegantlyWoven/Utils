using System;
using System.IO;
using System.Xml.Linq;

namespace Utils
{
    public class SimpleXmlConfigFile
    {
        const String DEFAULT_FILENAME = "Settings.xml";

        public SimpleXmlConfigFile(String filename = DEFAULT_FILENAME)
        {
            _elRoot = null;

            try
            {
                _elRoot = XElement.Load(filename);
            }
            catch (FileNotFoundException)
            { }
        }

        public String GetConfigEntry(String section, String name)
        {
            String v = null;

            if (_elRoot != null)
            {
                XElement elSection = _elRoot.Element(section);
                if (elSection != null)
                {
                    XElement elName = elSection.Element(name);
                    if (elName != null)
                    {
                        v = elName.Value;
                    }
                }
            }

            return v;
        }

        private XElement _elRoot;
    }
}

