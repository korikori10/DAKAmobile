using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DBServices
/// </summary>
public class DBServices
{
	public DBServices()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    List<Product> ls = new List<Product>();

    public List<Product> getList()
    {
        Dictionary<string, string> Attributes = new Dictionary<string, string>();
        Attributes.Add("מוצר איכותי", "המוצר מכיל רכיבים איכותיים ללא בלאיי עם אחריות לשנתיים");
        Attributes.Add("משלוח מהיר", "משלוחים מהירים עד בית הלקוח");
        Attributes.Add("אספקה מהירה", "מתחייבים לקבלת המוצרים עד 48 שעות מההזמנה");
        Attributes.Add("תשלומים", "אפשרות לקבל עד 5 תשלומים ללא ריבית");
        Attributes.Add("קניה מאובטחת", "קנייה מאובטחת באחריות");

        Dictionary<string, string> Attributes2 = new Dictionary<string, string>();


        ls.Add(new Product(1, 1, "A new green chair", "images/chair1.jpg", 150, 4, Attributes));
        ls.Add(new Product(1, 2, "A chair for a dining area", "images/chair2.jpg", 220, 5, Attributes));
        ls.Add(new Product(1, 3, "A chair in a new style", "images/chair3.jpg", 215, 1, Attributes2));
        ls.Add(new Product(1, 4, "A black chair", "images/chair4.jpg", 199, 0, Attributes));
        ls.Add(new Product(1, 5, "A garden chair", "images/no-img.jpg", 179, 6, Attributes));
        ls.Add(new Product(1, 6, "A chair for children", "images/chair6.jpg", 250, 8, Attributes2));


        ls.Add(new Product(2, 7, "table", "images/table1.jpg", 150, 8, Attributes));
        ls.Add(new Product(2, 8, "table", "images/table2.jpg", 180, 4, Attributes2));
        ls.Add(new Product(2, 9, "table", "images/table3.jpg", 220, 1, Attributes));
        ls.Add(new Product(2, 10, "table", "images/table4.jpg", 275, 2, Attributes));


        ls.Add(new Product(3, 11, "armchair", "images/armchair1.jpg", 150, 0, Attributes));
        ls.Add(new Product(3, 12, "armchair", "images/armchair2.jpg", 180, 6, Attributes2));
        ls.Add(new Product(3, 13, "armchair", "images/armchair3.jpg", 220, 7, Attributes));
        ls.Add(new Product(3, 14, "armchair", "images/no-img.jpg", 275, 8, Attributes));
        ls.Add(new Product(3, 15, "armchair", "images/armchair5.jpg", 310, 1, Attributes2));
        ls.Add(new Product(3, 16, "armchair", "images/armchair6.jpg", 270, 2, Attributes));
        ls.Add(new Product(3, 17, "armchair", "images/armchair7.jpg", 295, 5, Attributes));


        ls.Add(new Product(4, 18, "bed", "images/bed1.jpg", 150, 8, Attributes));
        ls.Add(new Product(4, 19, "bed", "images/bed2.jpg", 150, 1, Attributes));
        ls.Add(new Product(4, 20, "bed", "images/bed3.jpg", 150, 5, Attributes));
        ls.Add(new Product(4, 21, "bed", "images/bed4.jpg", 150, 4, Attributes2));
        ls.Add(new Product(4, 22, "bed", "images/bed5.jpg", 150, 6, Attributes));
        ls.Add(new Product(4, 23, "bed", "images/bed6.jpg", 150, 2, Attributes));
        ls.Add(new Product(4, 24, "bed", "images/bed7.jpg", 150, 0, Attributes));
        ls.Add(new Product(4, 25, "bed", "images/bed8.jpg", 150, 1, Attributes2));
        ls.Add(new Product(4, 26, "bed", "images/bed9.jpg", 150, 4, Attributes));


        ls.Add(new Product(5, 27, "carpet", "images/carpet1.jpg", 150, 0, Attributes));
        ls.Add(new Product(5, 28, "carpet", "images/carpet2.jpg", 180, 6, Attributes2));
        ls.Add(new Product(5, 29, "carpet", "images/no-img.jpg", 220, 7, Attributes));
        ls.Add(new Product(5, 30, "carpet", "images/carpet4.jpg", 275, 8, Attributes));
        ls.Add(new Product(5, 31, "carpet", "images/carpet5.jpg", 310, 1, Attributes2));
        ls.Add(new Product(5, 32, "carpet", "images/carpet6.jpg", 270, 2, Attributes));
        ls.Add(new Product(5, 33, "carpet", "images/carpet7.jpg", 295, 5, Attributes));



        ls.Add(new Product(6, 34, "shelf", "images/shelf1.jpg", 150, 8, Attributes));
        ls.Add(new Product(6, 35, "shelf", "images/shelf2.jpg", 180, 4, Attributes2));
        ls.Add(new Product(6, 36, "shelf", "images/shelf3.jpg", 220, 1, Attributes));
        ls.Add(new Product(6, 37, "shelf", "images/shelf4.jpg", 275, 2, Attributes));


        ls.Add(new Product(7, 38, "sofa", "images/sofa1.jpg", 150, 8, Attributes));
        ls.Add(new Product(7, 39, "sofa", "images/no-img.jpg", 180, 4, Attributes2));
        ls.Add(new Product(7, 40, "sofa", "images/sofa3.jpg", 220, 1, Attributes));
        ls.Add(new Product(7, 41, "sofa", "images/sofa4.jpg", 275, 2, Attributes));
        ls.Add(new Product(7, 42, "sofa", "images/sofa5.jpg", 275, 2, Attributes));


        ls.Add(new Product(8, 43, "stool", "images/stool1.jpg", 150, 0, Attributes));
        ls.Add(new Product(8, 44, "stool", "images/stool2.jpg", 180, 6, Attributes2));
        ls.Add(new Product(8, 45, "stool", "images/stool3.jpg", 220, 7, Attributes));
        ls.Add(new Product(8, 46, "stool", "images/stool4.jpg", 275, 8, Attributes));


        ls.Add(new Product(9, 47, "wardrobe", "images/wardrobe1.jpg", 150, 0, Attributes));
        ls.Add(new Product(9, 48, "wardrobe", "images/wardrobe2.jpg", 180, 6, Attributes2));
        ls.Add(new Product(9, 49, "wardrobe", "images/no-img.jpg", 220, 7, Attributes));
        ls.Add(new Product(9, 50, "wardrobe", "images/wardrobe4.jpg", 275, 8, Attributes));
        ls.Add(new Product(9, 51, "wardrobe", "images/wardrobe5.jpg", 310, 1, Attributes2));

        return ls;

    }
    public List<Category> getCategory()
    {
        List<Category> ls1= new List<Category>();

        ls1.Add(new Category(1, "chair", 6));
        ls1.Add(new Category(2, "table", 4));
        ls1.Add(new Category(3, "armchair", 7));
        ls1.Add(new Category(4, "bed", 9));
        ls1.Add(new Category(5, "carpet", 7));
        ls1.Add(new Category(6, "shelf", 4));
        ls1.Add(new Category(7, "sofa", 5));
        ls1.Add(new Category(8, "stool", 4));
        ls1.Add(new Category(9, "wardrobe", 5));


        return ls1;
        
    }

    public List<Product> getProductsByCat(int categoryId)
    {
       List<Product> pl = getList();
       List<Product> pl1 = new List<Product>();

       foreach (Product p in pl)
       {
           if (p.category.Id == categoryId)
               pl1.Add(p);
       }

       return pl1;
    }

    public Product getProduct(int productId)
    {
        List<Product> pl = getList();
        Product p1 = new Product();
        foreach (Product p in pl)
        {
            if (p.Id == productId)
                p1 = p;
        }
        return p1;
       
        

    }


}