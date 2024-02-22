package com.example.exam.views

import androidx.compose.foundation.layout.Column
import androidx.compose.material3.Button
import androidx.compose.material3.Text
import androidx.compose.runtime.Composable
import androidx.compose.runtime.livedata.observeAsState
import com.example.exam.entities.Employee
import com.example.exam.viewmodels.MainViewModel

var nextId = 1

@Composable
fun DatabaseScreen(
    model: MainViewModel
) {
    val data = model.getAllEmployees().observeAsState()

    Column {
        data.value?.let { list ->
            for (item in list) {
                Text(item.name)
            }
        }

        Button(onClick = {
            model.addEmployee(
                Employee(
                id = nextId,
                name = "Employee $nextId",
                experience = 1.2,
                email = "employee$nextId@gmail.com",
                phone = "+380487498234"
            )
            )

            nextId++
        }) {
            Text("Add new employee")
        }
    }
}
