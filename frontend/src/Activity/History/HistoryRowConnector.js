import PropTypes from 'prop-types';
import React, { Component } from 'react';
import { connect } from 'react-redux';
import { createSelector } from 'reselect';
import { fetchHistory, markAsFailed } from 'Store/Actions/historyActions';
import createMovieSelector from 'Store/Selectors/createMovieSelector';
import createUISettingsSelector from 'Store/Selectors/createUISettingsSelector';
import HistoryRow from './HistoryRow';

function createMapStateToProps() {
  return createSelector(
    createMovieSelector(),
    createUISettingsSelector(),
    (movie, uiSettings) => {
      return {
        movie,
        shortDateFormat: uiSettings.shortDateFormat,
        timeFormat: uiSettings.timeFormat
      };
    }
  );
}

const mapDispatchToProps = {
  fetchHistory,
  markAsFailed
};

class HistoryRowConnector extends Component {

  //
  // Lifecycle

  componentDidUpdate(prevProps) {
    if (
      prevProps.isMarkingAsFailed &&
      !this.props.isMarkingAsFailed &&
      !this.props.markAsFailedError
    ) {
      this.props.fetchHistory();
    }
  }

  //
  // Listeners

  onMarkAsFailedPress = () => {
    this.props.markAsFailed({ id: this.props.id });
  };

  //
  // Render

  render() {
    return (
      <HistoryRow
        {...this.props}
        onMarkAsFailedPress={this.onMarkAsFailedPress}
      />
    );
  }

}

HistoryRowConnector.propTypes = {
  id: PropTypes.number.isRequired,
  isMarkingAsFailed: PropTypes.bool,
  markAsFailedError: PropTypes.object,
  fetchHistory: PropTypes.func.isRequired,
  markAsFailed: PropTypes.func.isRequired
};

export default connect(createMapStateToProps, mapDispatchToProps)(HistoryRowConnector);
