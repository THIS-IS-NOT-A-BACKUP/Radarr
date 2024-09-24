import React from 'react';
import { Ratings, RatingValues } from 'Movie/Movie';
import translate from 'Utilities/String/translate';
import styles from './RottenTomatoRating.css';

interface RottenTomatoRatingProps {
  ratings: Ratings;
  iconSize?: number;
  hideIcon?: boolean;
}

function RottenTomatoRating(props: RottenTomatoRatingProps) {
  const { ratings, iconSize = 14, hideIcon = false } = props;

  const rtRotten =
    'data:image/svg+xml;base64,PHN2ZyB2aWV3Qm94PSIwIDAgNTYwIDU2MCIgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIj48cGF0aCBkPSJNNDQ1LjE4NSA0NDQuNjg0Yy03OS4zNjkgNC4xNjctOTUuNTg3LTg2LjY1Mi0xMjYuNzI2LTg2LjAwNi0xMy4yNjguMjc5LTIzLjcyNiAxNC4xNTEtMTkuMTMzIDMwLjMyIDIuNTI1IDguODg4IDkuNTMgMjEuOTIzIDEzLjk0NCAzMC4wMTEgMTUuNTcgMjguNTQ0LTcuNDQ3IDYwLjg0NS0zNC4zODMgNjMuNTc3LTQ0Ljc2IDQuNTQtNjMuNDMzLTIxLjQyNi02Mi4yNzgtNDguMDA3IDEuMy0yOS44NCAyNi42LTYwLjMzMS42NS03My4zMDUtMjcuMTk0LTEzLjU5Ny00OS4zMDEgMzkuNTcyLTc1LjMyNSA1MS40MzktMjMuNTUzIDEwLjc0MS01Ni4yNDggMi40MTMtNjcuODcyLTIzLjc0MS04LjE2NC0xOC4zNzktNi42OC01My43NjggMjkuNjctNjcuMjcgMjIuNzA2LTguNDMzIDczLjMwNSAxMS4wMjkgNzUuOS0xMy42MjMgMi45OTItMjguNDE2LTUzLjE1NS0zMC44MTItNzAuMDYtMzcuNjI2LTI5LjkxMi0xMi4wNTUtNDcuNTY3LTM3Ljg1LTMzLjczNC02NS41MjIgMTAuMzc4LTIwLjc1NyA0MC45MTUtMjkuMjAzIDY0LjIyMy0yMC4xMSAyNy45MjIgMTAuODkyIDMyLjQwNCAzOS44NTMgNDYuNzEgNTEuODk3IDEyLjMyNCAxMC4zOCAyOS4xOSAxMS42OCA0MC4yMiA0LjU0MyA4LjEzNS01LjI2NSAxMC44NDMtMTYuODI4IDcuNzc0LTI3LjM5LTQuMDctMTQuMDIzLTE0Ljg3NS0yMi43NzMtMjUuNDE1LTMxLjM0Ni0xOC43NTgtMTUuMjQ5LTQ1LjI0LTI4LjM2LTI5LjIyMi02OS45ODMgMTMuMTMtMzQuMTEgNTEuNjQyLTM1LjM0IDUxLjY0Mi0zNS4zNCAxNS4zLTEuNzIgMjkuMDAyIDIuOSA0MC4xNjcgMTIuODc1IDE0LjkyNyAxMy4zMzUgMTcuODM0IDMxLjE2IDE1LjMzNiA1MC4xNzYtMi4yODMgMTcuMzU4LTguNDI2IDMyLjU2LTExLjYzIDQ5Ljc1OS0zLjcxNyAxOS45NjYgNi45NTQgNDAuMDg2IDI3LjI0OSA0MC44NjkgMjYuNjk0IDEuMDMxIDM0LjY5OC0xOS40ODYgMzcuOTY0LTMyLjQ5MiA0Ljc4Mi0xOS4wMjggMTEuMDU4LTM2LjY5NCAyOC43MTgtNDcuODIgMjUuMzQ2LTE1Ljk3IDYwLjU1Mi0xMi40NyA3Ni44ODYgMTguMjIyIDEyLjkyIDI0LjI4NCA4Ljc3MiA1Ny43MTUtMTEuMDQ3IDc1Ljk3LTguODkyIDguMTg4LTE5LjU4NCAxMS4wNzUtMzEuMTQ4IDExLjE1Ni0xNi41ODUuMTE3LTMzLjE2Mi0uMjktNDguNTU2IDcuNDcxLTEwLjQ4IDUuMjgxLTE1LjA0NyAxMy44ODgtMTUuMDQ1IDI1LjQyMyAwIDExLjI0MiA1Ljg1MyAxOC41ODUgMTUuMzM2IDIzLjM2MyAxNy44NiA5LjAwMyAzNy41NzcgMTAuODQzIDU2Ljg3MSAxNC4yMjIgMjcuOTggNC45IDUyLjU4MSAxNC43NTUgNjguMzc1IDQwLjcyLjE0Mi4yMjguMjguNDU4LjQxNS42OSAxOC4xMzkgMzAuNzQxLS44MzEgNzUuMDA1LTM2LjQ3NiA3Ni44NzgiIGZpbGw9IiMwQUM4NTUiLz48L3N2Zz4=';
  const rtFresh =
    'data:image/svg+xml;base64,PHN2ZyB2aWV3Qm94PSIwIDAgNTYwIDU2MCIgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIj48cGF0aCBkPSJtNDc4LjI5IDI5Ni45OGMtMy45OS02My45NjYtMzYuNTItMTExLjgyLTg1LjQ2OC0xMzguNTggMC4yNzggMS41Ni0xLjEwOSAzLjUwOC0yLjY4OCAyLjgxOC0zMi4wMTYtMTQuMDA2LTg2LjMyOCAzMS4zMi0xMjQuMjggNy41ODQgMC4yODUgOC41MTktMS4zNzggNTAuMDcyLTU5LjkxNCA1Mi40ODMtMS4zODIgMC4wNTYtMi4xNDItMS4zNTUtMS4yNjgtMi4zNTQgNy44MjgtOC45MjkgMTUuNzMyLTMxLjUzNSA0LjM2Ny00My41ODYtMjQuMzM4IDIxLjgxLTM4LjQ3MiAzMC4wMTctODUuMTM4IDE5LjE4Ni0yOS44NzggMzEuMjQxLTQ2LjgwOSA3NC00My40ODUgMTI3LjI2IDYuNzggMTA4Ljc0IDEwOC42MyAxNzAuODkgMjExLjE5IDE2NC40OSAxMDIuNTYtNi4zOTUgMTkzLjQ3LTgwLjU3MiAxODYuNjgtMTg5LjMxIiBmaWxsPSIjRkEzMjBBIi8+PHBhdGggZD0iTTI5MS4zNzUgMTMyLjI5M2MyMS4wNzUtNS4wMjMgODEuNjkzLS40OSAxMDEuMTE0IDI1LjI3NCAxLjE2NiAxLjU0NS0uNDc1IDQuNDY4LTIuMzU1IDMuNjQ4LTMyLjAxNi0xNC4wMDYtODYuMzI4IDMxLjMyLTEyNC4yODIgNy41ODQuMjg1IDguNTE5LTEuMzc4IDUwLjA3Mi01OS45MTQgNTIuNDgzLTEuMzgyLjA1Ni0yLjE0Mi0xLjM1NS0xLjI2OC0yLjM1NCA3LjgyOC04LjkyOSAxNS43My0zMS41MzUgNC4zNjctNDMuNTg2LTI2LjUxMiAyMy43NTgtNDAuODg0IDMxLjM5Mi05OC40MjYgMTUuODM4LTEuODgzLS41MDgtMS4yNDEtMy41MzUuNzYyLTQuMjk4IDEwLjg3Ni00LjE1NyAzNS41MTUtMjIuMzYxIDU4LjgyNC0zMC4zODUgNC40MzgtMS41MjYgOC44NjItMi43MSAxMy4xOC0zLjQtMjUuNjY1LTIuMjkzLTM3LjIzNS01Ljg2Mi01My41NTktMy40LTEuNzg5LjI3LTMuMDA0LTEuODEzLTEuODk1LTMuMjQxIDIxLjk5NS0yOC4zMzIgNjIuNTEzLTM2Ljg4OCA4Ny41MTItMjEuODM3LTE1LjQxLTE5LjA5NC0yNy40OC0zNC4zMjEtMjcuNDgtMzQuMzIxbDI4LjYwMS0xNi4yNDZzMTEuODE3IDI2LjQgMjAuNDE0IDQ1LjYxNGMyMS4yNzUtMzEuNDM1IDYwLjg2LTM0LjMzNiA3Ny41ODUtMTIuMDMzLjk5MiAxLjMyNi0uMDQ1IDMuMjEtMS43MDIgMy4xNzEtMTMuNjEyLS4zMzEtMjEuMTA3IDEyLjA1LTIxLjY3NSAyMS40NjZsLjE5Ny4wMjMiIGZpbGw9IiMwMDkxMkQiLz48L3N2Zz4=';

  const { rottenTomatoes: rottenTomatoesRatings = {} as RatingValues } =
    ratings;
  const { value = 0 } = rottenTomatoesRatings;

  const ratingImage = value > 50 ? rtFresh : rtRotten;

  return (
    <span className={styles.wrapper}>
      {!hideIcon && (
        <img
          className={styles.image}
          alt={translate('RottenTomatoesRating')}
          src={ratingImage}
          style={{
            height: `${iconSize}px`,
          }}
        />
      )}
      {value}%
    </span>
  );
}

export default RottenTomatoRating;
