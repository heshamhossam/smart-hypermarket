package com.hci.smarthypermarket.test;

import java.util.ArrayList;

import com.hci.smarthypermarket.Order;
import com.hci.smarthypermarket.Product;

import android.test.AndroidTestCase;

public class OrderTest extends AndroidTestCase {
	
	public void testConstructor()
	{
		Order order = new Order();
		assertNotNull(order);
	}
	public void testGetProductList(){
		Order order = new Order();
		order.addProduct(new Product("1","manga","4848",20));
		order.addProduct(new Product("2","moz","7474",30));
		ArrayList<Product> actualList = new ArrayList<Product>();
		actualList.add(new Product("1","manga","4848",20));
		actualList.add(new Product("2","moz","7474",30));
		ArrayList<Product>expectedList = order.getProducts();
		assertSame(expectedList, expectedList);
	}
	public void testListSize(){
		Order order = new Order();
		Product p1 = new Product("1","Pepsi","1234",20);
		p1.setPurchasedQuantity(2);
		Product p2 = new Product("1","Pepsi","1234",20);
		p2.setPurchasedQuantity(3);
		order.addProduct(p1);
		order.addProduct(p2);
	    assertEquals(order.getProducts().size(), 1);
	
		
		
		
				
	}

}
