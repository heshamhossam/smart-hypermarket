package com.hci.smarthypermarket;

import java.util.ArrayList;
import java.util.List;
import org.apache.http.NameValuePair;
import org.apache.http.impl.entity.LaxContentLengthStrategy;
import org.apache.http.message.BasicNameValuePair;
import org.json.JSONException;
import org.json.JSONObject;

import android.R.string;
import android.animation.ValueAnimator;
import android.location.Location;
import android.os.AsyncTask;
import android.util.Log;

abstract class RetrieveProductTask extends AsyncTask<String, Integer, Product> {

	// ////////////////////////////
	final String TAG_PID = "id";
	final String TAG_NAME = "name";
	final String TAG_BARCODE = "barcode";
	final String TAG_PRICE = "price";
	final String TAG_CATID = "category_id";
	final String TAG_SUCCESS = "success";
	final String TAG_PRODUCT = "product";
	// //////////////////////////////////

	JSONParser jsonParser = new JSONParser();

	private static final String url_product_detials = "http://zonlinegamescom.ipage.com/smarthypermarket/public/products/retrieve";

	private Product p = new Product();

	@SuppressWarnings("finally")
	@Override
	protected Product doInBackground(String... params) {

		// TODO Auto-generated method stub
		try {
			int success;

			List<NameValuePair> CParams = new ArrayList<NameValuePair>();
			CParams.add(new BasicNameValuePair("barcode", params[0]));

			JSONObject json = jsonParser.makeHttpRequest(url_product_detials,
					"GET", CParams);

			success = json.getInt(TAG_SUCCESS);
			if (success == 1) {

				JSONObject productObj = json.getJSONObject(TAG_PRODUCT);
				String id = productObj.getString(TAG_PID);
				String name = productObj.getString(TAG_NAME);
				String barcode = productObj.getString(TAG_BARCODE);
				float price = Float.parseFloat(productObj.getString(TAG_PRICE));
				String categoryId = productObj.getString(TAG_CATID);
				
				p = new Product(id, name, barcode, price, categoryId);

				return p;
			} else {
			}
		} catch (JSONException e) {
			e.printStackTrace();
		} finally {
			return p;
		}
	}

}
abstract class RetrieveLocationTask extends AsyncTask<Location, Integer, Market> {

	// ////////////////////////////
	final String TAG_MID = "id";
	final String TAG_MNAME = "name";
	final String Latitude="latitude";
	final String TAG_SUCCESS = "success";
	final String Longtitude="longitude";
	final String TAG_Market = "market";
	// //////////////////////////////////

	JSONParser jsonParser = new JSONParser();
	private static final String url_market_detials = "http://zonlinegamescom.ipage.com/smarthypermarket/public/markets/retrieve";
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
					
					
					market = new Market(id, name);

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



public abstract class WebService implements IWebService {

	

	protected void onProductDetected(Product product)
	{
		
	}

	// ///////////////////////////////////////////////////////
	@Override
	public void getProduct(final String barcode) {
		RetrieveProductTask retrieveProduct = new RetrieveProductTask() {
			protected void onPostExecute(Product result) {
				onProductDetected(result);
			}
		};

		retrieveProduct.execute(barcode);
	}
	
	
	protected void onMarketDetected(Market market)
	{
		
	}
	
	@Override
	public void getMarket(Location location) {
		
		RetrieveLocationTask retrieveLocationTask = new RetrieveLocationTask() {
			protected void onPostExecute(Market market)
			{
				onMarketDetected(market);
			}
		};
		
		retrieveLocationTask.execute(location);
	}
	
	

}