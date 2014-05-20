package com.hci.smarthypermarket.test;

import java.util.ArrayList;

import com.hci.smarthypermarket.models.Order;
import com.hci.smarthypermarket.models.Product;

import android.test.AndroidTestCase;
import junit.framework.TestCase;

public class OrderTest extends AndroidTestCase {
	public void testConstructor()
	 	{
	 		Order order = new Order();
	 		assertNotNull(order);
	 	}
	 	public void testGetProductList(){
	 		Order order = new Order();
	 	    order.addProduct(new Product("1","manga","4848",20, null, null));
	 		order.addProduct(new Product("2","moz","7474",30, null, null));
	 		ArrayList<Product> actualList = new ArrayList<Product>();
	 		actualList.add(new Product("1","manga","4848",20, null, null));
	 		actualList.add(new Product("2","moz","7474",30, null, null));
	 		ArrayList<Product>expectedList = order.getProducts();
	 	//	assertSame(expectedListزش\\, actualList);
	 		assertEquals(expectedList.size(), actualList.size());
	 	}
	 	public void testListSize(){
	 		Order order = new Order();
	 		Product p1 = new Product("1","Pepsi","1234",20, null, null);
	 		p1.setPurchasedQuantity(2);
	 		Product p2 = new Product("1","Pepsi","1234",20, null, null);
	 		p2.setPurchasedQuantity(3);
	 		order.addProduct(p1);
	 		order.addProduct(p2);
	 	    assertEquals(order.getProducts().size(), 1);
	 	
	 }
	 	public void testTotalCost(){
	 		Order order = new Order();
	 		
	 		order.addProduct(new Product("1", "pepsi", "1234",(float) 2.0,"123", "good"));
	 		order.addProduct(new Product("2", "lemon", "123",(float) 3.0,"123", "good"));
	 		order.addProduct(new Product("4", "mooz", "12",(float) 1.0,"123", "good"));
	 		order.addProduct(new Product("5", "tofa7 a5dar", "1",(float) 4.0,"123", "good"));
	 		assertEquals((float)10, order.getTotalCost());
	 		
	 		
	 		
	 	}
}

