package com.hci.smarthypermarket;

import java.util.List;

import android.location.Location;
import android.util.Log;

public class Market {

	private int id;
	private Location location;
	private List<Category> categories;
	private List<Product> products;
	
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
				
				try
				{
					if(product.getBarcode().toString().compareTo(barCode) == 0)
						return product;
				}
				catch (Exception e)
				{
					return null;
				}
			}
			
		}
		return null;
		
	}
	List<Product> getproducts(){
		for(Category cat : this.categories)
		{
			for(Product product : cat.products)
			{
				products.add(product);
			}
		}
		return null;
		
	}
	
	

}
