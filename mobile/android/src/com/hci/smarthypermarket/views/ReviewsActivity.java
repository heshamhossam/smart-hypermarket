package com.hci.smarthypermarket.views;

import java.util.List;

import android.app.Activity;
import android.os.Bundle;
import android.widget.ArrayAdapter;
import android.widget.ListView;

import com.hci.smarthypermarket.R;
import com.hci.smarthypermarket.models.Review;


public class ReviewsActivity extends Activity {
	
	private ListView ReviewsListView;

	public ReviewsActivity() {
		// TODO Auto-generated constructor stub
	}
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		// TODO Auto-generated method stub
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_reviews);
		
		ReviewsListView = (ListView) findViewById(R.id.ReviewList);
		
		if (LauncherActivity.shopper.getScannedProduct() != null)
		{
			showReviews(LauncherActivity.shopper.getScannedProduct().getReviews());
		}
	}
	
	private void showReviews(List<Review> reviews)
	{
		ArrayAdapter<Review> adapter = new ReviewsListAdapter(this, reviews);
		ReviewsListView.setAdapter(adapter);
	}

}
