package com.hci.smarthypermarket.models;

public class Review extends Model {
	
	protected Shopper reviewer;
	protected String id;
	protected String body;
	protected String createdAt;
	protected String updatedAt;
	
	
	public Review(Shopper reviewer, String id, String body, String createdAt, String updatedAt) {
		super();
		this.reviewer = reviewer;
		this.id = id;
		this.body = body;
		this.createdAt = createdAt;
		this.updatedAt = updatedAt;
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
//		SendReviewTask sendReviewTask = new SendReviewTask() {
//
//			@Override
//			protected void onPostExecute(Review result) {
//				mirrior(result);
//				modelHandler.OnModelSent();
//			}
//			
//		};
//		sendReviewTask.execute(this);
		
		
		
	}
	
	
	
	

}
