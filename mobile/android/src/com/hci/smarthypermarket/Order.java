package com.hci.smarthypermarket;

import java.util.ArrayList;
import java.util.Iterator;

import android.R.string;
import android.app.Activity;
import android.util.Log;
import android.widget.ArrayAdapter;
import android.widget.ListView;

public class Order {
	
	private ArrayList<Product> products = new ArrayList<Product>();
	private String id;
	private String confirmationCode;
	private String state;
	
	

	public void setProducts(ArrayList<Product> products) {
		this.products = products;
	}


	public Order()
	{
	
	}


	public void showProductsItems(Activity activity, ListView listProducts) {
		ArrayAdapter<Product> adapter = new CartListAdapter(activity, products);
		listProducts.setAdapter(adapter);
		
	}

	public ArrayList<Product> getProducts() {
		return products;
		
	}
	
	public void addProduct(Product product) {
		//check if it exist in the orders
		Iterator<Product> iteratorProducts = products.iterator();
		Boolean productFound = false;
		while (iteratorProducts.hasNext())
		{
			Product currProduct = iteratorProducts.next();
			
			if ( currProduct.getId().compareTo(product.getId()) == 0 )
			{
				currProduct.setPurchasedQuantity(currProduct.getPurchasedQuantity() + product.getPurchasedQuantity());
				productFound = true;
				break;
			}
		}
		
		if (!productFound)
		{
			products.add(product);
		}
	}
	public String getId() {
		return id;
	}


	public void setId(String id) {
		this.id = id;
	}


	public String getConfirmationCode() {
		return confirmationCode;
	}


	public void setConfirmationCode(String confirmationCode) {
		this.confirmationCode = confirmationCode;
	}


	public String getState() {
		return state;
	}


	public void setState(String state) {
		this.state = state;
	}



}
