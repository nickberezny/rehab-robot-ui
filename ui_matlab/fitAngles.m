function fitAngles(app)
    global Mar206;
    app.JointQ1 = Mar206.VarName2;
    app.JointQ2 = Mar206.VarName4;
    app.JointX1 = linspace(0,0.4,length(app.JointQ1));
    app.JointX2 = linspace(0,0.4,length(app.JointQ2));

    hold(app.UIAxes3, 'off');
    hold(app.UIAxes3_2, 'off');

    plot(app.UIAxes3, app.JointX1, app.JointQ1);
    plot(app.UIAxes3_2, app.JointX2, app.JointQ2);

    Q = app.JointQ1(app.P1EditField.Value:app.P2EditField.Value);
    X = app.JointX1(app.P1EditField.Value:app.P2EditField.Value)

    f = fit(X',Q,'poly2');
    app.JointF1 = f(X)

    hold(app.UIAxes3, 'on');
    plot(app.UIAxes3, [X]', [app.JointF1]);

    Q = app.JointQ2(app.P1EditField_2.Value:app.P2EditField_2.Value);
    X = app.JointX2(app.P1EditField_2.Value:app.P2EditField_2.Value);

    f = fit(X',Q,'poly2');
    app.JointF2 = f(X);
    
    hold(app.UIAxes3_2, 'on');
    plot(app.UIAxes3_2, X, app.JointF2);
    
end 