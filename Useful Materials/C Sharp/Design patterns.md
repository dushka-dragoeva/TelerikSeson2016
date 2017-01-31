#Design Patterns

Instance
IMessageWriter writer = new ConsoleMessageWriter();

To enable late binding, you might replace that line of code with something like this:

var typeName =
ConfigurationManager.AppSettings["messageWriter"];
var type = Type.GetType(typeName, true);
IMessageWriter writer =
(IMessageWriter)Activator.CreateInstance(type);

By pulling the type name from the application configuration file and creating a Type instance from it, you can use Reflection to
create an instance of IMessageWriter without knowing the concrete type at compile time.

**To make this work, you specify the type name in the messageWriter application setting in the application configuration
file:**
<appSettings>
<add key="messageWriter"
value="Ploeh.Samples.HelloDI.CommandLine.ConsoleMessageWriter,
HelloDI" />
</appSettings>



List<DEPARTMENTs> list =   db.DEPARTMENTs.Join(db.DEPT_PROFILE, dept => dept.DEPT_CODE, prof => prof.DEPT_CODE, (dept,prof) => new {dept, prof})
            .Join(Wdb.WEB_ACCESS, depts => depts.prof.USER_ID,web => web.USER_ID,(depts,web) => new { depts, web})
            .Where(result => result.web.EMP_ID== id).Select(s => s.depts.dept).ToList<DEPARTMENTs>();
