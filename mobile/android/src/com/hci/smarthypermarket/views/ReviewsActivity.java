package com.hci.smarthypermarket.views;

import java.util.List;

import android.app.Activity;
import android.os.Bundle;

import com.hci.smarthypermarket.models.Review;
import com.hci.smarthypermarket.models.Shopper;

public class ReviewsActivity extends Activity {

	public ReviewsActivity() {
		// TODO Auto-generated constructor stub
	}
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		// TODO Auto-generated method stub
		super.onCreate(savedInstanceState);
		
		
		if (LauncherActivity.shopper.getScannedProduct() != null)
		{
			showReviews(LauncherActivity.shopper.getScannedProduct().getReviews());
		}
	}
	
	private void showReviews(List<Review> reviews)
	{
		//implement de yad
	}

}
