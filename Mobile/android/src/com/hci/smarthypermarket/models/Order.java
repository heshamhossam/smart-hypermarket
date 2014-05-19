package com.hci.smarthypermarket.models;

import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;

import com.hci.smarthypermarket.views.CartListAdapter;
import com.hci.smarthypermarket.views.IShowableItem;


import android.app.Activity;

import android.widget.ArrayAdapter;
import android.widget.ListView;



public class Order extends Model {
	
	public static final String WAITING = "WAITING";
	public static final String READY = "READY";
	public static final String PREPARING = "PREPARING";
	public static final String DONE = "DONE";
	
	private ArrayList<Product> products = new ArrayList<Product>();
	private ArrayList<Offer> offers = new ArrayList<Offer>();
	
	private String id;
	private String confirmationCode;
	private String state;
	private float totalCost;
	

	public void setProducts(ArrayList<Product> products) {
		this.products = products;
	}


	public Order()
	{
	
	}


	public void showProductsItems(Activity activity, ListView listProducts) {
		ArrayAdapter<IShowableItem> adapter = new CartListAdapter(activity, this.getAllShowableItems());
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


	public float getTotalCost() {
		
		if (totalCost > 0)
			return totalCost;
		
		totalCost = 0;
		for (Product produt : products) {
			totalCost += produt.price;
		}
		
		return totalCost;
	}


	public ArrayList<Offer> getOffers() {
		return offers;
	}
	
	public List<IShowableItem> getAllShowableItems(){
		List<IShowableItem> showableItems = new ArrayList<IShowableItem>();
		for(Product product : this.products){
			showableItems.add(product);
		}
		for(Offer offer : this.offers){
			showableItems.add(offer);
		}
		return showableItems;
	}



}
