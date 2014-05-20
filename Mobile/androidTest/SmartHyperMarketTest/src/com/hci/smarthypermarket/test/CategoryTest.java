package com.hci.smarthypermarket.test;

import java.util.ArrayList;
import java.util.List;

import com.hci.smarthypermarket.models.Category;
import com.hci.smarthypermarket.models.Offer;
import com.hci.smarthypermarket.models.Product;

import junit.framework.TestCase;

public class CategoryTest extends TestCase {

	public void testCategory() {
		Category category = new Category();
		assertNotNull(category);
	}

	public void testCategoryStringString() {
		Category category = new Category("7", "Test");
		assertNotNull(category);
	}

	public void testGetProducts() {
		Category category = new Category();
		List<Product> products = new ArrayList<Product>();
		products.add(new Product("12", "Pepsi", "3607214116", (float) 24.5, "700", "this is a soda drink"));
		products.add(new Product("23", "Headphone", "6920652801883", (float) 35.5, "700", "A Very Bad Headphone will damage your ears"));
		category.setProducts(products);
		
		List<Product> products1 = category.getProducts();
		
		String actual = products1.get(0).getName();
		String expected = "Pepsi";
		
		assertEquals(expected, actual);
	}


	public void testHasOffer() {
		Category categoryBooks = new Category("5", "Books");
		List<Product> products = new ArrayList<Product>();
		products.add(new Product("12", "Pepsi", "3607214116", (float) 24.5, "700", "this is a soda drink"));
		products.add(new Product("23", "Headphone", "6920652801883", (float) 35.5, "700", "A Very Bad Headphone will damage your ears"));
		categoryBooks.setProducts(products);
		List<Offer> offers = new ArrayList<Offer>();
		offers.add(new Offer("offer test", "120", "Test offer teaser 1", "5-7-1993", "5-7-2014", categoryBooks.getProducts()));
		
		String actual = categoryBooks.hasOffer(offers).getName();
		String expected = "offer test";
		
		assertEquals(expected, actual);
	}
}
