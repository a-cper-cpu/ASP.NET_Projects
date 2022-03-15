using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public class Animal
{
	public string sflag;
	public virtual void Bit()
	{
		sflag = "This is an animal.";
	}
}

public class Cat:Animal
{
	public override void Bit()
	{
		sflag = "This is a cat.";
	}
}

public class Dog:Animal
{
	public override void Bit()
	{
		sflag = "This is a dog.";
	}
}

public partial class UsingOverload : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		TestOverload();
		Response.End();
    }

	public void TestOverload()
	{
		Animal animal = new Animal();
		Cat cat = new Cat();
		Dog dog = new Dog();

		animal.Bit();
		cat.Bit();
		dog.Bit();
		Response.Write("Animal class: " + animal.sflag + "<br>");
		Response.Write("Cat class: " + cat.sflag + "<br>");
		Response.Write("Dog class: " + dog.sflag + "<br>");		
	}
}
