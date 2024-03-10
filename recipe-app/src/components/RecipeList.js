import React from "react";

const RecipeList = ({ recipes }) => {
  return (
    <div>
      {recipes.map((recipe) => (
        <div key={recipe.id}>
          <h2>{recipe.name}</h2>
          <p>{recipe.instructions}</p>
          {/* Display other recipe details */}
        </div>
      ))}
    </div>
  );
};

export default RecipeList;
