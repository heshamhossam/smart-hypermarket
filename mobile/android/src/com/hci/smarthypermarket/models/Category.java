package com.hci.smarthypermarket.models;

import java.util.ArrayList;
import java.util.List;

import org.apache.http.NameValuePair;
import org.apache.http.message.BasicNameValuePair;
import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;


import android.os.AsyncTask;
import android.util.Log;


abstract class RetriveCategoriesTask extends AsyncTask<Market, Integer,List<Category>>
{
//////////////////////Categories Tags/////////////////////
	final String Tag_Categories="categories";
	final String Tag_CategoryId="id";
	final String Tag_CategoryName="name";
/////////////////////Products Tags/////////////////////
	final String TAG_PRODUCTS="products";
	final String TAG_PID = "id";
	final String TAG_NAME = "name";
	final String TAG_BARCODE = "barcode";
	final String TAG_PRICE = "price";
	final String TAG_CATID = "category_id";
	final String TAG_SUCCESS = "success";
	final String TAG_PRODUCT = "product";
	final String TAG_PDISC="description";
	final String TAG_PWIGH="weight";
	////////////////////////////////////
	JSONArray products = null;
	JSONArray categories=null;
	ArrayList<Category> CategoriesR= new ArrayList<Category>();
	JSONParser jsonParser= new JSONParser();
	JSONParser jsonParser1= new JSONParser();
	private static final String url_categories_detials= Model.linkServiceRoot + "/categories/get";
	private static final String url_products_ofcategory=Model.linkServiceRoot + "/products/get";
	@Override
	protected List<Category> doInBackground(Market... params) {
		 List<NameValuePair> params1 = new ArrayList<NameValuePair>();
		 params1.add(new BasicNameValuePair("market_id", String.valueOf(params[0].getId())));
		JSONObject json =jsonParser.makeHttpRequest(url_categories_detials, "GET", params1);
		try {
			categories =json.getJSONArray(Tag_Categories);
			for(int i =0;i<categories.length();i++)
			{
				JSONObject c = categories.getJSONObject(i);
				String CatId= c.getString(Tag_CategoryId);
				String CatName=c.getString(Tag_CategoryName);
				List<NameValuePair>params2 = new ArrayList<NameValuePair>();
				Category cat = new Category(CatId,CatName);
				ArrayList<Product>productL = new ArrayList<Product>();
				params2.add(new BasicNameValuePair("market_id","1"));
				params2.add(new BasicNameValuePair("category_id",CatId));
				Log.d("catid", CatId);
				JSONObject json2 = jsonParser1.makeHttpRequest(url_products_ofcategory,"GET", params2);
				Log.d("products", json2.toString());
				products = json2.getJSONArray(TAG_PRODUCTS);
			
				for(int j =0;j<products.length();j++)
				{
					JSONObject c2 = products.getJSONObject(j);
					String id = c2.getString(TAG_PID);
					String name = c2.getString(TAG_NAME);
					String barcode = c2.getString(TAG_BARCODE);
					float price = Float.parseFloat(c2.getString(TAG_PRICE));
					String Discription = c2.getString(TAG_PDISC);
					String Weight = c2.getString(TAG_PWIGH);
					Product P =  new Product(id, name, barcode, price, Weight, Discription);
					productL.add(P);
				}
				cat.setProducts(productL);
				CategoriesR.add(cat);
				
				//Category category = new Category(id, name, createdAt, updatedAt, parentId)
			}
		} catch (JSONException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
			return null;
		}
		Log.d("categoriesSSSSSSS", Integer.toString(CategoriesR.size()));
			params[0].setCategories(CategoriesR);
			return CategoriesR;
		
	}
	
}



public class Category extends Model {
	
	protected String id;
	protected String name;
	protected String createdAt;
	protected String updatedAt;
	protected String parentId;
	protected Boolean fetched = false;
	protected static List<Category> allCategories;
	
	protected List<Product> products;
	
	
	
	public Category()
	{
		
	}

	public Category(String id, String name )
	{
		this.id = id;
		this.name = name;
	
	}
	
	
	public String getId() {
		return id;
	}
	public String getName() {
		return name;
	}
	public String getCreatedAt() {
		return createdAt;
	}
	public String getUpdatedAt() {
		return updatedAt;
	}
	public String getParentId() {
		return parentId;
	}
	
	public List<Product> getProducts() {
		return products;
	}


	public void setProducts(List<Product> products) {
		this.products = products;
	}
	
	public static void all(Market market)
	{
		
		RetriveCategoriesTask retriveCategoriesTask = new RetriveCategoriesTask() {
			protected void onPostExecute(List<Category>list)
			{
				isAllFetched = true;
				allCategories = list;
				OnAllModelsRetrieved.OnModelRetrieved();
			}
		};
		retriveCategoriesTask.execute(market);
	}

	public static List<Category> getAllCategories() {
		
		if (allCategories != null)
		{
			isAllFetched = false;
			return allCategories;
		}
		
		return null;
	}

	
	

	
	
	

}