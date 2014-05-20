package com.hci.smarthypermarket.models;

import java.util.ArrayList;
import java.util.List;

import org.apache.http.NameValuePair;
import org.apache.http.message.BasicNameValuePair;
import org.json.JSONException;
import org.json.JSONObject;

import android.os.AsyncTask;



abstract class SendReviewTask extends AsyncTask<Review, Integer, Review>
{
	
	/////////////////Reviews Tags////////////////
	final String Tag_ReviewBody="body";
	final String Tag_ProductId="product_id";
	final String Tag_UserId="user_id";
	final String Tag_Updatedat="updated_at";
	final String Tag_Createdat="created_at";
	final String Tag_ReviewID="id";
	final String Tag_UserMobile="mobile";
	final String Tag_Rating = "rating";
	//////////////////////////////////////////
	private static final String url_create_review=Model.linkServiceRoot + "/reviews/create";
	JSONParser jsonParser = new JSONParser();
	
	
	@Override
	protected Review doInBackground(Review... params) {
		// TODO Auto-generated method stub
		List<NameValuePair> CParms = new ArrayList<NameValuePair>();
		
		CParms.add(new BasicNameValuePair(Tag_ProductId, params[0].getProductId()));
		CParms.add(new BasicNameValuePair(Tag_ReviewBody, params[0].getBody()));
		CParms.add(new BasicNameValuePair(Tag_Rating, String.valueOf( params[0].getRating() ) ));
		CParms.add(new BasicNameValuePair(Tag_UserMobile, params[0].getReviewer().getMobile()));
		JSONObject jsonObject = jsonParser.makeHttpRequest(url_create_review, "GET", CParms);
		try {
			String Createdat=jsonObject.getString(Tag_Createdat);
			String  Updatedat=jsonObject.getString(Tag_Updatedat);
			String ReviewId=jsonObject.getString(Tag_ReviewID);
			
			params[0].createdAt=Createdat;
			params[0].updatedAt=Updatedat;
			params[0].id=ReviewId;
			
		} catch (JSONException e1) {
			// TODO Auto-generated catch block
			e1.printStackTrace();
		}
		return params[0];
	}
	  
	
}


public class Review extends Model {

	protected Shopper reviewer;
	protected String id;
	protected String body;
	protected String createdAt;
	protected String updatedAt;
	protected String product_id;
	private float rating;
	
	
	public Review(Shopper reviewer, String id, String body, String createdAt, String updatedAt,float rating) {
		super();
		this.reviewer = reviewer;
		this.id = id;
		this.body = body;
		this.createdAt = createdAt;
		this.updatedAt = updatedAt;
		this.rating = rating;
		
	}
	
	
	public Review(Shopper reviewer, String body, float rating) {
		super();
		this.reviewer = reviewer;
		this.body = body;
		this.rating = rating;
	}
	

	public Review() {
		
	}
	
	protected void mirror(Review review)
	{
		this.id = review.id;
		this.createdAt = review.createdAt;
	}
	
	public void save()
	{
		SendReviewTask sendReviewTask = new SendReviewTask() {
			@Override
			protected void onPostExecute(Review result) {
				mirror(result);
				modelHandler.OnModelSent();
			}
	
		};
		sendReviewTask.execute(this);
	
	}



	public void setProductId(String product_id) {
		this.product_id = product_id;
	}
	
	public String getName(){
		return reviewer.getFirstName();
	}
	
	public String getBody(){
		return body;
	}
	
	public float getRating()
	{
		return rating;
	}

	public String getProductId()
	{
		return product_id;
	}


	public Shopper getReviewer() {
		return reviewer;
	}
	

	
	

}
