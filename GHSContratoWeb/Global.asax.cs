using Stimulsoft.LicenseHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace GHSContratoWeb
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            StimulsoftLicenseHelper.Activate();

            Stimulsoft.Base.StiLicense.Key = "6vJhGtLLLz2GNviWmUTrhSqnOItdDwjBylQzQcAOiHnkVfyflHUL/+4gH7OSwehGNSlTBABYKpQQ2FNXkzu3NsIpXSB7hnZzvpeW" +
      "EoNISJd1S3Ax6Ui05lVjsgJHbFvNJTADWIgsTR2An5UMgCS5od8DZllrjpZz1yzoBKrJR7ycBVBpYZ/PCICkKrD5+hDha4EtoBEv" +
      "ZJZREqtsw5j2gPQ4v5ilmtXCjtnKV7a0yzok6xb8/DKnBA1BneKxKJp1EOywhUXsGEVFhZpY6/i7UZpVDfKeKCIiCzYyIQXyYg6y" +
      "TI7d/GPax/C4hnXaRG503s8fgE2NF5C+R644lIJTWuBKhRANAMc13iPSFXpQqsTQVaCh+x6sOvhqiLf8OmBCWDRmU3Cmk4JFUDL7" +
      "JGZlSs8jtgWo1sSEdikH2z9f+1qOo9NbKDEDp5epPbLCA16I24T1BPI8X6vzMm0cuOMchCuLN3pGQLZymSNLjjIov52NAbfwkjP4" +
      "4dP/r+6+y80Mmw+lfqHkw1LZArcgK7Jmi02kPhBNRX1SmBpmLKnoOQsG4iYYl7mRX/JtFc4bb8mWbcKQrLIL5Vj2nYbY/tKUvkcU" +
      "A6XRO66eB4wKEV5rD0Lb/2MvvYrsjvXdeOTBjvPnC8+sWdxrzkVTpfbaBy1EX99OKHdOS5yYU3u3dEldbIDE1E0CwRFieXDk00UJ" +
      "PvAAKElWfEz93ijFxVKl3FVlli0LEvXlwWuJSF66xuCKKuR2FI8QM7qCSuILHH3LED4No+pKOFcFOV1qKup8SGr3EySrXOYkzAED" +
      "/dv+q8OK2XI7eBLQISR1bnF2S6wRqls5PJJ20cSNYAXKq1yI9pOy6xKoBz7HhE5aDBhiPyraVHGAg/uCrnUVikk51YrLMGk8bdlE" +
      "1s2Gj9vbGBYAipb0IqZfN7mZXDsuViLMjxA9GkvaDk4znCSKlMZoDW7h/ZsjNXOYgSc3/4l6i2/i1M5zLz5ifr22DBzVh0vbfIOa" +
      "hRPrjl74Ik1b/u4AhuhbZ5T3TN+bKa5uSngcqTVOtvB/rB3NWxrJ+bAjsa3UUFdqqQUSk+wNLMN/vlij+Q+/jOq+6LnLI6cpnw2Z" +
      "ok+K4lZ7MUdxrlMk397WzdSUwFWNuFb0coM7Op76b2jE7H99IvHzvwOoFSigUMoAnm/ugNd70X14dbb+LTM1PlmbfY2GLqM67vKK" +
      "bsucZu+xA6A/FpWzwTnekbfy8PNcOwqNbJAEs8m7M6I0OUp73bvIZr3e2XC0jwf8UiJzRRJ9kJxVlI74uqERGzlxALlC9g2Jn4fD" +
      "ncGBW5gvBECsi3MP8C/XkpmaU7xbUly28qoJEPcrslM9z+fYNJ1yKhB0EVpQ8Z8jPkUKoMnQtB0fq8gSPpXJQEwQSORl4TTDR/dP" +
      "MdzDuXk7zAOrWAjvd1rnih8a9qvXNnf/JJx8CCGeleZRoTqcJ6PaaBO7Qy/LTQkVG5ZhBbbPweGwx4F1SyyIMmjeIJdqPHHcuOAd" +
      "knqdCCUSQooy+gX6qcQNU17zG6NuE+r2a/QOWyPdiaa9dEaHNKUbRkJ/BBQLSv1ZmVNCwzzT8LOmg7KbvbS53JDT1daps2pED8SY" +
      "8eHsD2Ng4rBO+r+Xhtn4s5VAlfS2c5+lX+1Rvvt/PKvsr+kuG5tZR7/aIk3Cq701/3bSiXhG4YiXZSBr3YQrlQ==";

            //seta a  linguagem do visualizador
            Stimulsoft.Base.Localization.StiLocalization.Load(Server.MapPath("~/Content/Localization/pt-BR.xml"));
        }
    }
}
