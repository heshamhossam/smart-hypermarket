package com.hci.smarthypermarket;

import java.util.ArrayList;

import android.app.Activity;
import android.widget.ArrayAdapter;
import android.widget.ListView;

public class Order {
	
	private ArrayList<Product> products = new ArrayList<Product>();
	
	
	public void showProductsItems(Activity activity, ListView listProducts) {
		ArrayAdapter<Product> adapter = new CartListAdapter(activity, products);
		listProducts.setAdapter(adapter);
		
	}

	public ArrayList<Product> getProducts() {
		return products;
	}


}
