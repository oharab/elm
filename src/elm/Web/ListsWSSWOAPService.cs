
using System;
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
		
		public ILogger Log {
			get { return log; }
			set { log = value; }
		}
		
		public ListsWSSWOAPService(Uri Uri)
		{
			this.Url=Uri.AbsoluteUri;
		}

		[SoapDocumentMethodAttribute("http://schemas.microsoft.com/sharepoint/soap/CheckInFile", RequestNamespace="http://schemas.microsoft.com/sharepoint/soap/", ResponseNamespace="http://schemas.microsoft.com/sharepoint/soap/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public bool CheckInFile(string pageUrl, string comment, string CheckinType) {
			object[] results = this.Invoke("CheckInFile", new object[] {
			                               	pageUrl,
			                               	comment,
			                               	CheckinType});
			return ((bool)(results[0]));
		}
		
		[SoapDocumentMethodAttribute("http://schemas.microsoft.com/sharepoint/soap/CheckOutFile", RequestNamespace="http://schemas.microsoft.com/sharepoint/soap/", ResponseNamespace="http://schemas.microsoft.com/sharepoint/soap/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
		public bool CheckOutFile(string pageUrl, string checkoutToLocal, string lastmodified) {
			object[] results = this.Invoke("CheckOutFile", new object[] {
			                               	pageUrl,
			                               	checkoutToLocal,
			                               	lastmodified});
			return ((bool)(results[0]));
		}
	}
}
