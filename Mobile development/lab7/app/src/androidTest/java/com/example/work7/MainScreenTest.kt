package com.example.work7

import androidx.compose.material3.Text
import androidx.compose.runtime.mutableStateOf
import androidx.compose.ui.test.assertHasClickAction
import androidx.compose.ui.test.assertIsDisplayed
import androidx.compose.ui.test.hasText
import androidx.compose.ui.test.isNotDisplayed
import androidx.compose.ui.test.junit4.createComposeRule
import androidx.compose.ui.test.onNodeWithText
import androidx.compose.ui.test.performClick
import org.junit.*

class MainScreenTest {
    @get:Rule
    val composeTestRule = createComposeRule()

    @Test
    fun should_contains_hello_world() {
        composeTestRule.setContent {
            MainScreen()
        }

        composeTestRule.onNode(hasText("Hello world")).assertIsDisplayed()
    }

    @Test
    fun should_contains_button() {
        composeTestRule.setContent {
            MainScreen()
        }

        composeTestRule.onNode(
            hasText("Click me!") or hasText("Thanks!")
        ).assertIsDisplayed()
    }

    @Test
    fun should_contains_button_not_clicked() {
        composeTestRule.setContent {
            MainScreen()
        }

        composeTestRule.onNodeWithText("Click me!").assertHasClickAction()
        composeTestRule.onNodeWithText("Button was not clicked.").assertIsDisplayed()
        composeTestRule.onNodeWithText("Button was clicked.").isNotDisplayed()
    }

    @Test
    fun should_contains_button_was_clicked() {
        composeTestRule.setContent {
            MainScreen()
        }

        composeTestRule.onNodeWithText("Click me!").performClick()
        composeTestRule.onNodeWithText("Click me!").isNotDisplayed()
        composeTestRule.onNodeWithText("Button was not clicked.").isNotDisplayed()
        composeTestRule.onNodeWithText("Button was clicked.").assertIsDisplayed()
        composeTestRule.onNodeWithText("Thanks!").assertIsDisplayed()
    }

    @Test
    fun should_auto_sync_count_state() {
        val myCounter = mutableStateOf(0)
        var lastSeenValue = 0

        composeTestRule.setContent {
            Text(myCounter.value.toString())
            lastSeenValue = myCounter.value
        }

        myCounter.value = 1

        composeTestRule.onNodeWithText("1").assertExists()
    }
}