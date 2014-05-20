package com.hci.smarthypermarket.models;



import java.util.ArrayList;
import java.util.List;

import org.apache.http.NameValuePair;
import org.apache.http.message.BasicNameValuePair;
import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import com.hci.smarthypermarket.views.IShowableItem;


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
	final String TAG_PDISC="description";
	final String TAG_PWIGH="weight";
	final String Tag_Review="reviews";
	final String Tag_ReviewId="id";
	final String Tag_ReviewBody="body";
	final String Tag_Rating ="rating";
    final String Tag_User="user";
    final String Tag_UserId="id";
    final String Tag_UserFirstName="first_name";
    final String Tag_UserLastName="last_name";
    final String Tag_UserMobile="mobile";
    final String Tag_ReviewCreateTime="created_at";
    final String Tag_ReviewUpdateTime="updated_at";
    
	
	
	// //////////////////////////////////

	JSONParser jsonParser = new JSONParser();
	List<Review> reviewlist= new ArrayList<Review>();
	JSONArray reviews = null;
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
				reviews = productObj.getJSONArray(Tag_Review);
				Log.d("reviews", reviews.toString());
				for(int i =0;i<reviews.length();i++)
				{
					
					JSONObject reviewobject=reviews.getJSONObject(i);
					String reviewid=  reviewobject.getString(Tag_ReviewId);
					String reviewbody = reviewobject.getString(Tag_ReviewBody);
					JSONObject userobject=reviewobject.getJSONObject(Tag_User);
					String userid=userobject.getString(Tag_UserId);
					String userfirstName=userobject.getString(Tag_UserFirstName);
					String userlaStringName=userobject.getString(Tag_UserLastName);
					String mobilenumber=userobject.getString(Tag_UserMobile);
					String rcreatedat=userobject.getString(Tag_ReviewCreateTime);
					String rupdatedat=	userobject.getString(Tag_ReviewUpdateTime);
					String rating =userobject.getString(Tag_Rating);
					Review review = new Review(new Shopper(userfirstName,userlaStringName,mobilenumber),reviewid,reviewbody,rcreatedat,rupdatedat,Integer.parseInt(rating));
					reviewlist.add(review);
				}
			//	String categoryId = productObj.getString(TAG_CATID);
				Log.d("reviewslength", Integer.toString(reviewlist.size()));
				p = new Product(id, name, barcode, price ,Weight, Discription,reviewlist);
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

public class Product extends Model implements IShowableItem {
	
	protected String id;
	protected String name;
	protected String barcode;
	protected float price;
	protected String categoryId;
	protected int purchasedQuantity;
	private String description;
	private String weight;
	private List<Review> reviews;
	private float rating = 0;
	
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
		
		for (Review review : reviews) {
			this.rating += review.getRating();
		}
		
		this.rating /= this.reviews.size();
		
	}
	
	public Product(String id, String name, String barcode, float price,String weight,String discription) {
		this.id = id;
		this.name = name;
		this.barcode = barcode;
		this.price = price;
		this.description= discription;
		this.weight = weight;
	}
	public Product(String id, String name, String barcode, int  purchasedQuantity ,String weight,String discription) {
		this.id = id;
		this.name = name;
		this.barcode = barcode;
		this.purchasedQuantity = purchasedQuantity;
		this.description= discription;
		this.weight = weight;
	}
	
	public void mirror(Product product)
	{
		id = product.getId();
		name = product.getName();
		barcode = product.getBarcode();
		price = Integer.parseInt(product.getPrice());
		description = product.getDescription();
		weight = product.getWeight();
//		categoryId = product.getCategoryId();
	}
	
	public void makeReview(Review review)
	{
		review.setProductId(this.id);
		review.save();
		
		reviews.add(review);
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
	
	
	public void setPrice(int price) {
		this.price = price;
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
	
	
	
	@Override
	public String getQuantity() {
		return String.valueOf(purchasedQuantity);
	}

	@Override
	public String getPrice() {
		return String.valueOf(price);
	}
	
	@Override
	public String getName() {
		return name;
	}

	public int getPurchasedQuantity() {
		return purchasedQuantity;
	}
	
	
	
}
