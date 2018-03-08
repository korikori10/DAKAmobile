using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Category
/// </summary>
public class Category
{
	public Category()
	{
		//
		// TODO: Add constructor logic here
		//
	}



    private string name;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    private int productAmount;

    public int ProductAmount
    {
        get { return productAmount; }
        set { productAmount = value; }
    }

    private int id;

    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    public Category(int _id, string _name, int _productAmount)
    {
        Id = _id;
        Name = _name;
        ProductAmount = _productAmount;
    }

    public List<Category> getCategory()
    {
        //call the method getCategory from DBService
        DBServices db = new DBServices();
        return db.getCategory();
    }


    public List<Product> getProductsByCat(int categoryId)
    {
        //call the method getProductsByCat from DBService
        DBServices db = new DBServices();
        return db.getProductsByCat(categoryId);

    }
}