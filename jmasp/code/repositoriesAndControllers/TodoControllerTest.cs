/***
 * Excerpted from "Test Drive ASP.NET MVC",
 * published by The Pragmatic Bookshelf.
 * Copyrights apply to this code. It may not be used to create training material, 
 * courses, books, articles, and the like. Contact us if you are in doubt.
 * We make no guarantees that this code is fit for any purpose. 
 * Visit http://www.pragmaticprogrammer.com/titles/jmasp for more book information.
***/
[TestFixture]
public class TodoControllerTest
{
  private TestControllerBuilder builder;
  private TodoController todoController;
  private MockRepository mocks;
  private ISession session;
  private TodoRepository todoRepository;

  [SetUp]
  public void setup()
  {
    mocks = new MockRepository();
    builder = new TestControllerBuilder();
	session = mocks.DynamicMock<ISession>();
    todoRepository = mocks.StrictMock<TodoRepository>(session); 
    todoController = new TodoController(todoRepository); 
    builder.InitializeController(todoController); 
  }

  [Test]
  public void Should_Display_Todo_List_And_Logged_In_Users_Name()
  {
    const string userName = "Jonathan";
    var todoList = new List<Todo> 
      { new Todo { Title = "Refactor to NHibernate" } };

    builder.HttpContext.User = 
      new GenericPrincipal(new GenericIdentity(userName), null);

    Expect.Call(todoRepository.GetAll()).Return(todoList); 
    mocks.ReplayAll(); 

    var viewData = todoController.Index().
      AssertViewRendered().ViewData;

    Assert.AreEqual(todoList, viewData.Model);

    Assert.AreEqual(userName, viewData["UserName"]);
    mocks.VerifyAll(); 
  }
}
