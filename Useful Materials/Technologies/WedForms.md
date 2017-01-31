Assembly.GetExecutingAssembly().Location;

##Global.asax
Global.asax defines the HTTP application
Defines global application events like
-Application_Start
-Application_BeginRequest
-Application_EndRequest
-Application_Error

Application Lifecycle Events
HttpApplication have a complex pipeline to the process HTTP requests (read more)
Application_Start
Application_End
Application_Error
Application_BeginRequest
Application_EndRequest
Application_PreSendRequestHeaders
Application_ResolveRequestCache
Application_PreRequestHandlerExecute

…
Typically invokes BundleConfig, RouteConfig, FilterConfig, etc.

**Sample HTTP handler in C#:**
public class TelerikAcademyHttpHandler : IHttpHandler
{
  public void ProcessRequest(HttpContext context)
  { context.Response.Write("I am а HTTP handler."); }
  public bool IsReusable
  { get { return false; } }
}
Handler registration in Web.config:
<configuration><system.webServer><handlers>
  <add verb="*" path="*.academy" name="Academy's HTTP handler"
       type="TelerikAcademyHttpHandler"></add>
</handlers></system.webServer></configuration>

**HTTP Modules**
-HTTP modules can customize requests for resources that are serviced by ASP.NET
	It can intercept all HTTP requests and apply a custom logic
-Steps to create an HTTP Module
	Implement the IHttpModule interface
-Subscribe to events you want to intercept, e.g. HttpApplication.BeginRequest
	Register the HTTP module in Web.config in the section
	
##ASP.NET Master Pages

-Master pages in ASP.NET Web Forms start with the @Masterdirective
-Mostly the same attributes as the @Pagedirective
-Master pages can contain:
-Markup for the page (<html>,<body>,…)
-Standard contents (HTML, ASP.NET controls)
<asp:ContentPlaceHolder>controls which can be replaced in the content pages
They can be as much as we want. Can be in header, footer, body...
##Content Pages

-Content pagesderive the entire content and logic from their master page
-Use the @Page directive with MasterPageFile attribute pointing to the master page
-Replace a <asp:ContentPlaceHolder> from the master page by using the <asp:Content> control
-Set theContentPlaceHolderIDproperty
-Points to the ContentPlaceHolder from the Master page which content we want to replace

aspx - page
ascx - component - преизолзваеми комплненти за различни странички

Master page can be changed in OnPreInit (EventArgs e) => to overide the method

Code behing => only logic that menage the view, all business logic in PRESENTER

Ако нешто е стигнало до сървъра, не е нужно да го жръщаме и да го крием с логика 
на клиента а го махаме още на сървъра. Ако не ходи до сървъра, тогава го правим на клиента

The view raises an events and the ptesentera dispaches them (закача се за тях ) 

Web Controls

The bullet list has Display Mode: Text, Hyperlink, LinkButton