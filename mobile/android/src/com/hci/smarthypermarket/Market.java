package com.hci.smarthypermarket;

import java.util.List;

import android.location.Location;
import android.util.Log;

public class Market {

	private int id;
	private Location location;
	private List<Category> categories;
	
	public Location getLocation() {
		return location;
	}

	private String Name;
	
	protected void onMarketRetrieved(Market market)
	{
		;
	}
	
	
	protected void onCategoriesRetrieved(Market market)
	{
		;
	}

	public Market(int id,String Name) {
		this.id = id;
		this.Name= Name;
		
	}
	
	public Market(Location location) {
		final Market myMarket = this;
		WebService webservice = new WebService() {

			@Override
			protected void onMarketDetected(Market market) {
				// TODO Auto-generated method stub
				super.onMarketDetected(market);
				if (market != null)
				{
					id = market.getId();
					Name = market.Name;
					onMarketRetrieved(market);
				}
			}
			
			@Override
			protected void onCategoriesDetected(List<Category> list)
			{
				categories= list;
				onCategoriesRetrieved(myMarket);
			}
			
		};
		

		webservice.getMarket(location);
		webservice.getCategories(this);
	}
	
	public int getId() {
		return id;
	}




	public List<Category> getCategories() {
		return categories;
	}




	public void setCategories(List<Category> categories) {
		this.categories = categories;
	}
	
	Product findProduct(String barCode)
	{
		for (Category cat : this.categories) {
			
			for (Product product : cat.products) {
				if(product.getBarcode().equals(barCode))
				{
					return product;
				}
			}
			
		}
		return null;
		
	}
	
	

}
