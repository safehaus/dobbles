// Main app JS.

var api = (function () {

  var data = {
    question: 'Sample question ___.'
  };

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
      this.setState({
        screen: ChooseAnswer,
        props: {
          // TODO: get from service
          answers: ['answer 1', 'answer 2', api.data.answer]
        }
      });
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
        <button onClick={this.props.onEveryoneHere}>Everyone is here</button>
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
        <p>{api.data.question}</p>
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

var ChooseAnswer = React.createClass({
  propTypes: {
    answers: React.PropTypes.arrayOf(React.PropTypes.string)
  },

  render: function () {
    var answers = this.props.answers.map(function (answer) {
      return <button>{answer}</button>;
    });
    return (
      <div>
        <h2>Choose an answer</h2>
        <p>{api.data.question}</p>
        {answers}
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
