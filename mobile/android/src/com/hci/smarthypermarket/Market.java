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
	
	protected void onMarketRetrieved()
	{
		;
	}
	
	
	

	public Market(int id,String Name) {
		this.id = id;
		this.Name= Name;
		
	}
	
	public Market(Location location) {
		WebService webservice = new WebService() {

			@Override
			protected void onMarketDetected(Market market) {
				// TODO Auto-generated method stub
				super.onMarketDetected(market);
				if (market != null)
					onMarketRetrieved();
			}
			
		};
		
		webservice.getMarket(location);
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
	
	
	

}
