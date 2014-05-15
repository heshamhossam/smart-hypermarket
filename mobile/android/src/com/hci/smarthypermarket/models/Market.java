package com.hci.smarthypermarket.models;

import java.util.ArrayList;
import java.util.List;

import org.apache.http.NameValuePair;
import org.apache.http.message.BasicNameValuePair;
import org.json.JSONException;
import org.json.JSONObject;




import android.location.Location;
import android.os.AsyncTask;


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
	private List<Category> categories = new ArrayList<Category>();
	private List<Offer> offers;
	

	public Market(String id,String Name) {
		this.id = id;
		this.name= Name;
		
	}
	
	public Market(String id,String Name, Boolean isStatic) {
		this.id = id;
		this.name= Name;
		
		Category categorySoda = new Category("2", "Soda");
		categorySoda.setBluetooth(new Bluetooth("Soda", "Soda", 0));
		categorySoda.getProducts().add(new Product("12", "Pepsi", "3607214116", (float) 24.5, "700", "this is a soda drink"));
		categorySoda.setOffer(new Offer("Drink All Soda you want, Get it Now", "12", "Buy Three Pepsi Cans and get one Shweps for free", "5-7-1993", "5-7-2014", null));
		
		
		Category categoryElectronics = new Category("4", "Electronics");
		categoryElectronics.setBluetooth(new Bluetooth("Electronics", "Electronics", 0));
		categoryElectronics.getProducts().add(new Product("23", "Headphone", "6920652801883", (float) 35.5, "700", "A Very Bad Headphone will damage your ears"));
		categoryElectronics.getProducts().add(new Product("27", "Kinect", "6920652801883", (float) 699, "450", "This is a device where you can use it with xBox to play or with D.Ayman to develop."));
		categoryElectronics.setOffer(new Offer("Buy Kinect or I'll Kill You", "57", "Buy Kinect Device and take headphone for free, Hurry up before its finished!", "5-7-1993", "5-7-2014", null));
		
		Category categoryBooks = new Category("5", "Books");
		categoryBooks.setBluetooth(new Bluetooth("Books", "Books", 0));
		categoryBooks.getProducts().add(new Product("28", "Medical Imaging", "0819436232", (float) 80, "400", "this is a CS Book"));
		categoryBooks.getProducts().add(new Product("29", "Digital Image Processing", "9780982085400", (float) 87, "982", " a CS Book related to image manipulations"));
		categoryBooks.setOffer(new Offer("Never Stop Reading", "120", "Buy Medical Imaging book and take Digital Image Processing Book for free, Hurry up now before It's out of stock", "5-7-1993", "5-7-2014", null));
		
		categories.add(categorySoda);
		categories.add(categoryElectronics);
		categories.add(categoryBooks);
		
	}
	
	public Market(Location location) {
		
		RetrieveMarketTask retrieveMarketTask = new RetrieveMarketTask() {
			protected void onPostExecute(Market market)
			{
				mirror(market);
				
				Offer.all(market, new OnModelListener() {
					@Override
					public void OnModelRetrieved() {
						offers = Offer.getAllOffers();
					}
				});

				Category.all(market, new OnModelListener() {
					
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
		try
		{
			for (Category cat : this.categories) {
				
				for (Product product : cat.products) {
					
						if(product.getBarcode().toString().compareTo(barCode) == 0)
							return product;
				}
				
			}
		}
		catch (Exception ex)
		{
			return null;
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
	
	
	public Category findCategory(Bluetooth bluetooth){
		
		Category category = null;
		if (this.getCategories() != null)
		{
			for(Category cat : this.getCategories()) {
				if(cat.getBluetooth().getName().compareTo(bluetooth.getName()) == 0) {
					category = cat;
					break;
				}
			}
		}
		
		return category;
	}

	public List<Offer> getOffers() {
		return offers;
	}

}
