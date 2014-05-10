package com.hci.smarthypermarket.views;

import java.util.List;

import com.hci.smarthypermarket.models.Category;

import com.hci.smarthypermarket.R;
import android.app.Activity;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

public class CategoryAdapter extends ArrayAdapter<Category> {
	private Activity activity;
	private List<Category> categories;

	public CategoryAdapter(Activity activityContext,  List<Category> categories) {
		super(activityContext, R.layout.item_category, categories);
		this.activity = activityContext;
		this.categories = categories;
	}
	
	@Override
	public View getView(int position, View convertView, ViewGroup parent){
		View row = convertView;
		Category category = categories.get(position);
		if(row == null){
			row = activity.getLayoutInflater().inflate(R.layout.item_category, parent, false);
		}
		
		TextView CategoryName = (TextView) row.findViewById(R.id.textViewCategoryName);
		CategoryName.setText(category.getName());
		return row;
	}

}
