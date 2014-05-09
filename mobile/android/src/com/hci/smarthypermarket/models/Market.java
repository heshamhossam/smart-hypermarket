package com.hci.smarthypermarket.models;

import java.util.ArrayList;
import java.util.List;

import org.apache.http.NameValuePair;
import org.apache.http.message.BasicNameValuePair;
import org.json.JSONException;
import org.json.JSONObject;




import android.location.Location;
import android.os.AsyncTask;
import android.util.Log;


abstract class RetrieveMarketTask extends AsyncTask<Location, Integer, Market> {
	// ////////////////////////////
	final String TAG_MID = "id";
	final String TAG_MNAME = "name";
	final String Latitude="latitude";
	final String TAG_SUCCESS = "success";
	final String Longtitude="longitude";
	final String TAG_Market = "market";
	// //////////////////////////////////

	JSONParser jsonParser = new JSONParser();
	private static final String url_market_detials = Model.linkServiceRoot + "/markets/retrieve";
	Market market;

	@SuppressWarnings("finally")
	@Override
	protected Market doInBackground(Location... params) {
		

	// TODO Auto-generated method stub
	
		try{
			int success;
                  
			List<NameValuePair> CParams = new ArrayList<NameValuePair>();
			
			CParams.add(new BasicNameValuePair("latitude",Double.toString(params[0].getLatitude())));
			CParams.add(new BasicNameValuePair("longitude",Double.toString(params[0].getLongitude())));

			JSONObject json = jsonParser.makeHttpRequest(url_market_detials,
					"GET", CParams);
		
			success = json.getInt(TAG_SUCCESS);
			if (success == 1) {

				JSONObject productObj = json.getJSONObject(TAG_Market);
				int id = Integer.parseInt(productObj.getString(TAG_MID));
				String name = productObj.getString(TAG_MNAME);
				
				
				market = new Market(String.valueOf(id), name);
				

				return market;
			} else {
				return null;
			}
		} catch (JSONException e) {
			e.printStackTrace();
		} finally {
			return market;
		}
	}
}


public class Market extends Model {

	private String id;
	private String name;
	private Location location;
	private List<Category> categories;
	
	

	public Market(String id,String Name) {
		this.id = id;
		this.name= Name;
		
	}
	
	public Market(Location location) {
		
		RetrieveMarketTask retrieveMarketTask = new RetrieveMarketTask() {
			protected void onPostExecute(Market market)
			{
				mirror(market);
				Category.all(market);
				
				Category.setOnAllModelsRetrieved(new OnModelListener() {
					
					@Override
					public void OnModelRetrieved() {
						setCategories(Category.getAllCategories());
						modelHandler.OnModelRetrieved();
						
					}
				});
			}
		};
		
		retrieveMarketTask.execute(location);
		
	}
	
	public String getId() {
		return id;
	}

	public List<Category> getCategories() {
		return categories;
	}

	public void setCategories(List<Category> categories) {
		this.categories = categories;
	}
	
	public Product findProduct(String barCode)
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
	
	protected void mirror(Market market)
	{
		this.id = market.getId();
		this.name = market.getName();
	}

	public String getName() {
		return name;
	}
	
	public Location getLocation() {
		return location;
	}
	
	public List<Product> getproducts() {
		
		List<Product> products = null;
		
		for(Category cat : this.categories)
		{
			for(Product product : cat.products)
			{
				products.add(product);
			}
		}
		
		return products;
		
	}
	

}
