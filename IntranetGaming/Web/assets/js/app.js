﻿// Main app JS.

var api = (function () {

  var data = {};

  return {
    room: {
      join: function (name, roomCode) {
        data.name = name;
        data.roomCode = roomCode;
      }
    },
    fib: {
      send: function (answer) {
        data.answer = answer;
      }
    },
    data: data
  }
})();

var Fibbage = React.createClass({

  getInitialState: function () {
    var handleAllResponsesHere = function () {
      console.log('all responses here');
    }.bind(this);

    var handleFib = function () {
      this.setState({
        screen: WaitingForFibs,
        props: {
          onAllResponsesHere: handleAllResponsesHere
        }
      });
    }.bind(this);

    var handleEveryoneHere = function () {
      this.setState({
        screen: EnterFib,
        props: {
          onFib: handleFib
        }
      });
    }.bind(this);

    var handleJoin = function () {
      this.setState({
        screen: WaitingForPlayers,
        props: {
          onEveryoneHere: handleEveryoneHere
        }
      });
    }.bind(this);

    return {
      screen: JoinRoom,
      props: {
        onJoin: handleJoin
      }
    };
  },

  render: function () {
    return React.createElement(this.state.screen, this.state.props);
  }
});

var JoinRoom = React.createClass({
  propTypes: {
    onJoin: React.PropTypes.func.isRequired
  },

  render: function () {
    var join = function () {
      api.room.join(this.refs.name.getText(), this.refs.room.getText());
      // TODO: iff successful
      this.props.onJoin();
    }.bind(this);

    return (
      <div>
        <h2>Join a room</h2>
        <TextInput label='Room' ref='room'/>
        <TextInput label='Your Name' go='Join' action={join} ref='name'/>
      </div>
    );
  }
});

var WaitingForPlayers = React.createClass({
  propTypes: {
    onEveryoneHere: React.PropTypes.func
  },

  getInitialState: function () {
    return {
      // TODO: get from service
      playerCount: 0,
    }
  },

  render: function () {
    return (
      <div>
        <h2>Waiting for players</h2>
        <p>{this.state.playerCount} joined</p>
        <button onClick={this.props.onEveryoneHere}>Everyone's here</button>
      </div>
    );
  }
});

var EnterFib = React.createClass({
  propTypes: {
    onFib: React.PropTypes.func.isRequired
  },

  render: function () {
    var fib = function () {
      api.fib.send(this.refs.fib.getText());
      // TODO: iff successful
      this.props.onFib();
    }.bind(this);

    return (
      <div>
        <h2>Enter your fib</h2>
        <p>Sample question ___.</p>
        <TextInput label='Your fib' go='Send' action={fib} ref='fib'/>
      </div>
    );
  }
});

var WaitingForFibs = React.createClass({
  propTypes: {
    onAllResponsesHere: React.PropTypes.func.isRequired
  },

  getInitialState: function () {
    return {
      playersAnswered: []
    }
  },

  componentWillMount: function () {
    // TODO: get from service
    setTimeout(function () {
      this.props.onAllResponsesHere();
    }.bind(this), 2000);
  },

  render: function () {
    playersAnswered = this.state.playersAnswered.map(function (player) {
      return <p>{player}</p>
    });

    return (
      <div>
        <h2>Waiting for everyone to answer</h2>
        {playersAnswered}
      </div>
    );
  }
});

var TextInput = React.createClass({
  propTypes: {
    label: React.PropTypes.string.isRequired,
    go: React.PropTypes.string,
    action: React.PropTypes.func
  },

  getText: function () {
    return React.findDOMNode(this.refs.text).value;
  },

  render: function () {
    return (
      <div>
        <label>
          {this.props.label}
          <input type='text' ref='text'/>
        </label>
        {this.props.go ? <button onClick={this.props.action}>{this.props.go}</button> : ''}
      </div>
    );
  }
});

(function () {
  React.render(React.createElement(Fibbage, {}), document.querySelector('#reactify'));
})();
