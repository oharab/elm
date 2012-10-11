
using System;
using System.Net;
using System.Web.Services;
using System.Web.Services.Description;
using System.Web.Services.Protocols;

using Castle.Core.Logging;

namespace elm.Web
{

	[WebServiceBindingAttribute(Name="ListsSoap", Namespace="http://schemas.microsoft.com/sharepoint/soap/")]
	public class ListsWSSWOAPService:SoapHttpClientProtocol,IListsWSSSOAPService
	{
		private ILogger log=NullLogger.Instance;
		private const string SERVICE_PATH="/_vti_bin/Lists.asmx";
		public ILogger Log {
			get { return log; }
			set { log = value; }
		}
		
		public ListsWSSWOAPService()
		{
			this.Url="http://localhost/site" + SERVICE_PATH;
			this.Credentials=CredentialCache.DefaultNetworkCredentials;
		}

		[SoapDocumentMethodAttribute("http://schemas.microsoft.com/sharepoint/soap/CheckInFile", RequestNamespace="http://schemas.microsoft.com/sharepoint/soap/", ResponseNamespace="http://schemas.microsoft.com/sharepoint/soap/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public bool CheckInFile(string pageUrl, string comment, string CheckinType) {
			log.DebugFormat("Checking in '{0}'.",pageUrl);
			object[] results = this.Invoke("CheckInFile", new object[] {
			                               	pageUrl,
			                               	comment,
			                               	CheckinType});
			return ((bool)(results[0]));
		}
		
		[SoapDocumentMethodAttribute("http://schemas.microsoft.com/sharepoint/soap/CheckOutFile", RequestNamespace="http://schemas.microsoft.com/sharepoint/soap/", ResponseNamespace="http://schemas.microsoft.com/sharepoint/soap/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public bool CheckOutFile(string pageUrl, string checkoutToLocal, string lastmodified) {
			log.DebugFormat("Checking out '{0}'.",pageUrl);
			object[] results = this.Invoke("CheckOutFile", new object[] {
			                               	pageUrl,
			                               	checkoutToLocal,
			                               	lastmodified});
			return ((bool)(results[0]));
		}
		
		
		public Uri Uri {
			get {
				return new Uri(this.Url);
			}
			set {
				this.Url=value.AbsoluteUri + SERVICE_PATH;
			}
		}
	}
}
