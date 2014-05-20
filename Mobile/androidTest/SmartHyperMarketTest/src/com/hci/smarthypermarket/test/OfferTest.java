package com.hci.smarthypermarket.test;

import java.util.ArrayList;
import java.util.List;

import android.test.AndroidTestCase;

import com.hci.smarthypermarket.models.Offer;
import com.hci.smarthypermarket.models.Product;
import com.hci.smarthypermarket.views.IShowableItem;


public class OfferTest extends AndroidTestCase {

	
	public void testOffer() {
		List<Product> products = new ArrayList<Product>();
		products.add(new Product("12", "Pepsi", "3607214116", (float) 24.5, "700", "this is a soda drink"));
		products.add(new Product("23", "Headphone", "6920652801883", (float) 35.5, "700", "A Very Bad Headphone will damage your ears"));
		
		Offer offer = new Offer("Offer test", "Offer price","Offer teaser","Offer date","Offer date",products);
		
		assertNotNull(offer);
	}

	
	public void testGetProducts() {
		List<Product> products = new ArrayList<Product>();
		products.add(new Product("12", "Pepsi", "3607214116", (float) 24.5, "700", "this is a soda drink"));
		products.add(new Product("23", "Headphone", "6920652801883", (float) 35.5, "700", "A Very Bad Headphone will damage your ears"));
		
		Offer offer = new Offer("Offer test", "Offer price","Offer teaser","Offer date","Offer date",products);
		List<Product> products1 = offer.getProducts();
		
		String actual = products1.get(0).getName();
		String expected = "Pepsi";
		
		assertEquals(expected, actual);
	}

	public void testGetShowableItems() {
		List<Product> products = new ArrayList<Product>();
		products.add(new Product("12", "Pepsi", "3607214116", (float) 24.5, "700", "this is a soda drink"));
		products.add(new Product("23", "Headphone", "6920652801883", (float) 35.5, "700", "A Very Bad Headphone will damage your ears"));
		
		Offer offer = new Offer("Offer test", "Offer price","Offer teaser","Offer date","Offer date",products);
		List<IShowableItem> showableItems = offer.getShowableItems();
		
		String actual = showableItems.get(1).getName();
		String expected = "Headphone";
		
		assertEquals(expected, actual);
	}
}
