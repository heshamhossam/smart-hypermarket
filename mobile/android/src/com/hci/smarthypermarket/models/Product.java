package com.hci.smarthypermarket.models;



import java.util.ArrayList;
import java.util.List;

import org.apache.http.NameValuePair;
import org.apache.http.message.BasicNameValuePair;
import org.json.JSONException;
import org.json.JSONObject;


import android.os.AsyncTask;


abstract class RetrieveProductTask extends AsyncTask<String, Integer, Product> {

	// ////////////////////////////
	final String TAG_PID = "id";
	final String TAG_NAME = "name";
	final String TAG_BARCODE = "barcode";
	final String TAG_PRICE = "price";
	final String TAG_CATID = "category_id";
	final String TAG_SUCCESS = "success";
	final String TAG_PRODUCT = "product";
	final String TAG_PDISC="description";
	final String TAG_PWIGH="weight";
	// //////////////////////////////////

	JSONParser jsonParser = new JSONParser();

	private static final String url_product_detials = Model.linkServiceRoot + "/products/retrieve";

	private Product p = new Product();

	@SuppressWarnings("finally")
	@Override
	protected Product doInBackground(String... params) {

		// TODO Auto-generated method stub
		try {
			int success;

			List<NameValuePair> CParams = new ArrayList<NameValuePair>();
			CParams.add(new BasicNameValuePair("barcode", params[0]));
			CParams.add(new BasicNameValuePair("market_id","1"));

			JSONObject json = jsonParser.makeHttpRequest(url_product_detials,
					"GET", CParams);

			success = json.getInt(TAG_SUCCESS);
			if (success == 1) {

				JSONObject productObj = json.getJSONObject(TAG_PRODUCT);
				String id = productObj.getString(TAG_PID);
				String name = productObj.getString(TAG_NAME);
				String barcode = productObj.getString(TAG_BARCODE);
				float price = Float.parseFloat(productObj.getString(TAG_PRICE));
				String Discription = productObj.getString(TAG_PDISC);
				String Weight = productObj.getString(TAG_PWIGH);
			//	String categoryId = productObj.getString(TAG_CATID);
				
				p = new Product(id, name, barcode, price ,Weight, Discription);
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

public class Product extends Model {
	
	protected String id;
	protected String name;
	protected String barcode;
	protected float price;
	protected String categoryId;
	protected int purchasedQuantity;
	private String description;
	private String weight;
	private List<Review> reviews;
	
	public Product()
	{
		
	}
	
	public Product(String barCode) {
		
		RetrieveProductTask retrieveProduct = new RetrieveProductTask() {
			protected void onPostExecute(Product result) {
				isFetched = true;
				mirror(result);
				modelHandler.OnModelRetrieved();
			}
		};
		
		retrieveProduct.execute(barCode);
		
	}
	
	public String getId() {
		return id;
	}

	public String getCategoryId() {
		return categoryId;
	}

	public Product(String id, String name, String barcode, float price,String weight,String discription, List<Review> reviews) {
		this.id = id;
		this.name = name;
		this.barcode = barcode;
		this.price = price;
		this.description= discription;
		this.weight = weight;
		this.reviews = reviews;
	}
	
	public Product(String id, String name, String barcode, float price,String weight,String discription) {
		this.id = id;
		this.name = name;
		this.barcode = barcode;
		this.price = price;
		this.description= discription;
		this.weight = weight;
	}
	
	public void mirror(Product product)
	{
		id = product.getId();
		name = product.getName();
		barcode = product.getBarcode();
		price = product.getPrice();
		description = product.getDescription();
		weight = product.getWeight();
//		categoryId = product.getCategoryId();
	}
	
	public String getName() {
		return name;
	}
	public void setName(String name) {
		this.name = name;
	}
	public String getBarcode() {
		return barcode;
	}
	public void setBarcode(String barcode) {
		this.barcode = barcode;
	}
	public float getPrice() {
		return price;
	}
	public void setPrice(int price) {
		this.price = price;
	}
	public int getPurchasedQuantity() {
		return purchasedQuantity;
	}
	public void setPurchasedQuantity(int purchasedQuantity) {
		this.purchasedQuantity = purchasedQuantity;
	}
	
	public float getTotalPrice()
	{
		return purchasedQuantity * price;
	}

	public String getDescription() {
		return description;
	}

	public void setDescription(String description) {
		this.description = description;
	}

	public String getWeight() {
		return weight;
	}

	public void setWight(String wight) {
		this.weight = wight;
	}

	public List<Review> getReviews() {
		return reviews;
	}
	
	
	
}
