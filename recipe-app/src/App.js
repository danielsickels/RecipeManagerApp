import React, { useState, useEffect } from "react";
import axios from "axios";
import RecipeList from "./components/RecipeList";
import AddRecipeForm from "./components/AddRecipeForm";

function App() {
  const [recipes, setRecipes] = useState([]);

  useEffect(() => {
    fetchRecipes();
  }, []);

  const fetchRecipes = async () => {
    try {
      const response = await axios.get("http://localhost:5181/api/recipe");
      setRecipes(response.data);
    } catch (error) {
      console.error("Couldn't fetch recipes", error);
    }
  };

  const addRecipe = async (recipe) => {
    try {
      await axios.post("http://localhost:5181/api/recipe", recipe);
      fetchRecipes(); // Refresh the list after adding
    } catch (error) {
      console.error("Couldn't add the recipe", error);
    }
  };

  return (
    <div className="App">
      <h1>Recipes</h1>
      <AddRecipeForm addRecipe={addRecipe} />
      <RecipeList recipes={recipes} />
    </div>
  );
}

export default App;
