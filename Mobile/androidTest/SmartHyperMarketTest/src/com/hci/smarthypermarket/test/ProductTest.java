package com.hci.smarthypermarket.test;

import java.util.ArrayList;
import java.util.List;

import com.hci.smarthypermarket.models.Product;
import com.hci.smarthypermarket.models.Review;

import android.test.AndroidTestCase;

public class ProductTest extends AndroidTestCase {
	
	
	public void testProduct(){
		Product product = new Product();
		product.setBarcode("23456789");
		String expected ="23456789";
		assertEquals(expected, product.getBarcode());
	}
	
	public void testProductRating(){
		
		List<Review>list = new ArrayList<Review>();
		list.add(new Review(null, "review1", 1));
		list.add(new Review(null, "review2", 4));
		list.add(new Review(null, "review3", 5));
		list.add(new Review(null, "review4", 4));
		float expectedrating = (float)14/4;
		Product product = new Product("123", "pepsi", "1234", 10, "14", "disc", list);
	    assertEquals(expectedrating,product.getRating());
		
	}
	public void testMakeReview(){
		List<Review>list = new ArrayList<Review>();
		list.add(new Review(null, "review1", 1));
		list.add(new Review(null, "review2", 4));
		list.add(new Review(null, "review3", 5));
		list.add(new Review(null, "review4", 4));
		Product product = new Product("123", "pepsi", "1234", 10, "14", "disc", list);
		int expected = product.getReviews().size();
		Review review = new Review(null,"new review",20);
		product.makeReview(review);
		assertEquals(expected+1, product.getReviews().size());
	}


}
