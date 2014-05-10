package com.hci.smarthypermarket.views;

import java.util.List;

import android.app.ActionBar;
import android.app.Activity;
import android.content.Intent;
import android.graphics.Color;
import android.graphics.drawable.ColorDrawable;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
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
		
		ActionBar ab = getActionBar(); 
        ColorDrawable colorDrawable = new ColorDrawable(Color.rgb(10, 73, 88));     
        ab.setBackgroundDrawable(colorDrawable);
       
        ab.setDisplayShowHomeEnabled(false);
		
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
	
	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		MenuInflater mif = getMenuInflater();
		mif.inflate(R.menu.reviews_actionbar, menu);
		return super.onCreateOptionsMenu(menu);
	}
	
	@Override
	public boolean onOptionsItemSelected(MenuItem item){
		switch(item.getItemId()){
		case R.id.back_icon:
			startProductActivity();
			return true;
		case R.id.home_icon:
			startDashBoardActivity();
			return true;
		default:
			return super.onOptionsItemSelected(item);
		}
	}
	
	public void startDashBoardActivity(){
		Intent intent = new Intent(ReviewsActivity.this, DashBoardActivity.class);
		startActivity(intent);
	}
	
	public void startProductActivity() {
		Intent intent = new Intent(ReviewsActivity.this, ProductActivity.class);
		startActivity(intent);
	}

}
