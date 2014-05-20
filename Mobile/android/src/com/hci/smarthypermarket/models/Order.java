package com.hci.smarthypermarket.models;

import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;

import org.apache.http.NameValuePair;
import org.apache.http.message.BasicNameValuePair;
import org.json.JSONException;
import org.json.JSONObject;

import com.hci.smarthypermarket.views.CartListAdapter;
import com.hci.smarthypermarket.views.IShowableItem;


import android.app.Activity;

import android.os.AsyncTask;
import android.widget.ArrayAdapter;
import android.widget.ListView;


abstract class RetrieveOrderState extends AsyncTask<Order, Integer, Order>
{
	////Order State
	final String Tag_OrderState="state";
	final String Tag_OrderId="id";
	
	JSONParser jsonParser = new JSONParser();
	private static final String order_details_url=Model.linkServiceRoot+"/orders/get";
	@Override
	protected Order doInBackground(Order... params) {
		// TODO Auto-generated method stub
		List<NameValuePair>Params = new ArrayList<NameValuePair>();
		Params.add(new BasicNameValuePair(Tag_OrderId,params[0].getId()));
		JSONObject jsonObject = jsonParser.makeHttpRequest(order_details_url, "GET", Params);
		try {
			String state = jsonObject.getString(Tag_OrderState);
			params[0].setState(state);
		} catch (JSONException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		return params[0];
	}
}

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


	public void refreshState(OnModelListener onModelListener) {
		//find online the state of this order and set the local state member by the new one online
		
	}



}
