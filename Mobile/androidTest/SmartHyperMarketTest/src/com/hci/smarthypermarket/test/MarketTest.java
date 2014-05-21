package com.hci.smarthypermarket.test;

import java.util.ArrayList;
import java.util.List;

import android.test.AndroidTestCase;

import com.hci.smarthypermarket.models.Category;
import com.hci.smarthypermarket.models.Market;
import com.hci.smarthypermarket.models.Product;

public class MarketTest extends AndroidTestCase {

	public void testMarketStringString() {
		Market market = new Market("1", "lol");
		assertNotNull(market);
	}

	public void testMarketStringStringBoolean() {
		Market market = new Market("1", "lol", false);
		assertNotNull(market);
	}


	public void testGetCategories() {
		Market market = new Market("1", "lol");
		List<Category> categories = new ArrayList<Category>();
		categories.add(new Category("5", "Books"));
		categories.add(new Category("6", "Shirts"));
		market.setCategories(categories);
		Category category = market.getCategories().get(0);
		
		String actual = category.getName();
		String expected = "Books";
		
		assertEquals(expected, actual);
	}

	public void testFindProduct() {
		Market market = new Market("1", "lol");
		List<Product> products = new ArrayList<Product>();
		products.add(new Product("12", "Pepsi", "3607214116", (float) 24.5, "700", "this is a soda drink"));
		products.add(new Product("23", "Headphone", "6920652801883", (float) 35.5, "700", "A Very Bad Headphone will damage your ears"));
		List<Category> categories = new ArrayList<Category>();
		categories.add(new Category("4", "Electronics"));
		categories.add(new Category("5", "Books"));
		market.setCategories(categories);
		categories.get(0).setProducts(products);
		
		String actual = market.findProduct("6920652801883").getName();
		String expected = "Headphone";
		
		assertEquals(expected, actual);
	}

}
