package com.hci.smarthypermarket.views;

import java.util.List;

import com.hci.smarthypermarket.R;
import com.hci.smarthypermarket.models.Review;

import android.app.Activity;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

public class ReviewsListAdapter extends ArrayAdapter<Review> {
	
	private Activity activity;
	private List<Review> reviews;
	
	public ReviewsListAdapter(Activity activityContext, List<Review> reviews) {
		super(activityContext, R.layout.item_review, reviews);
		this.activity = activityContext;
		this.reviews = reviews;
	}

	public View getView(int Position, View convertView, ViewGroup parent){
		View itemView = convertView;
		if(itemView == null){
			itemView = activity.getLayoutInflater().inflate(R.layout.item_review, parent, false);
		}
		
		Review review = reviews.get(Position);
		
		TextView Reviewer = (TextView) itemView.findViewById(R.id.textViewReviewer);
		Reviewer.setText(review.getName());
		
		TextView ReviewBody = (TextView) itemView.findViewById(R.id.textViewReviewBody);
		ReviewBody.setText(review.getBody());
		
		return itemView;
	}
}